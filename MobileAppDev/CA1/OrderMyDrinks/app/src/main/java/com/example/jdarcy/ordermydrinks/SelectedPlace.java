package com.example.jdarcy.ordermydrinks;

/**
 * Created by jdarcy on 05/03/2016.
 */
import android.app.Activity;
import android.app.ProgressDialog;
import android.content.Intent;
import android.net.Uri;
import android.os.AsyncTask;
import android.os.Bundle;
import android.text.Html;
import android.util.Log;
import android.view.View;
import android.widget.Button;
import android.widget.TextView;
import android.widget.Toast;

public class SelectedPlace extends Activity {
    // flag for Internet connection status
    Boolean isInternetPresent = false;

    // Connection detector class
    ConnectionDetector cd;

    // Alert Dialog Manager
    AlertDialogManager alert = new AlertDialogManager();

    // Google Places
    GooglePlaces googlePlaces;

    // Place Details
    PlaceDetails placeDetails;

    // Progress dialog
    ProgressDialog pDialog;

    Button callButton;
    Button makeReservationButton;
    // KEY Strings
    public static String KEY_REFERENCE = "reference"; // id of the place

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.selected_place);

        Intent i = getIntent();

        // Place referece id
        String reference = i.getStringExtra(KEY_REFERENCE);

        // Calling a Async Background thread
        new LoadSelectedPlace().execute(reference);
        callButton = (Button) findViewById(R.id.btn_call_place);
        callButton.setOnClickListener(new View.OnClickListener() {
            public void onClick(View v) {
                call();
            }

        });

        makeReservationButton = (Button) findViewById(R.id.btn_make_reservation);
        makeReservationButton.setOnClickListener(new View.OnClickListener() {
            public void onClick(View v) {
                makeReservation();
            }

        });
    }

    private void call() {
        //define a new Intent for the Make Call Activity
        Intent intent = new Intent(Intent.ACTION_CALL, Uri.parse("0000000000"));
        intent.setPackage("com.android.server.telecom");
        intent.setData(Uri.parse("tel:91-000-000-0000"));
        try {
            //Launch the Phone bar Activity
            startActivity(intent);
        } catch (android.content.ActivityNotFoundException ex) {
            Toast.makeText(getApplicationContext(), "yourActivity is not founded", Toast.LENGTH_SHORT).show();
        }
    }

    public void makeReservation() {

            //define a new Intent for the Reservation details
            Intent intent = new Intent(this,ReservationDetails.class);
            try {
                //Launch the Reservation details Activity
                startActivity(intent);
            } catch (android.content.ActivityNotFoundException ex) {
                Toast.makeText(getApplicationContext(), "yourActivity is not founded", Toast.LENGTH_SHORT).show();
            }

    }



    /**
     * Background Async Task to Load Google places
     * */
    class LoadSelectedPlace extends AsyncTask<String, String, String> {

        /**
         * Before starting background thread Show Progress Dialog
         * */
        @Override
        protected void onPreExecute() {
            super.onPreExecute();
            pDialog = new ProgressDialog(SelectedPlace.this);
            pDialog.setMessage("Loading profile ...");
            pDialog.setIndeterminate(false);
            pDialog.setCancelable(false);
            pDialog.show();
        }

        /**
         * getting Profile JSON
         * */
        protected String doInBackground(String... args) {
            String reference = args[0];

            // creating Places class object
            googlePlaces = new GooglePlaces();

            // Check if used is connected to Internet
            try {
                placeDetails = googlePlaces.getPlaceDetails(reference);

            } catch (Exception e) {
                e.printStackTrace();
            }
            return null;
        }

        /**
         * After completing background task Dismiss the progress dialog
         * **/
        protected void onPostExecute(String file_url) {
            // dismiss the dialog after getting all products
            pDialog.dismiss();
            // updating UI from Background Thread
            runOnUiThread(new Runnable() {
                public void run() {

                    if(placeDetails != null){
                        String status = placeDetails.status;

                        // check place deatils status
                        // Check for all possible status
                        if(status.equals("OK")){
                            if (placeDetails.result != null) {
                                String name = placeDetails.result.name;
                                String address = placeDetails.result.formatted_address;
                                String phone = placeDetails.result.formatted_phone_number;
                                String latitude = Double.toString(placeDetails.result.geometry.location.lat);
                                String longitude = Double.toString(placeDetails.result.geometry.location.lng);

                                Log.d("Place ", name + address + phone + latitude + longitude);

                                // Displaying all the details in the view
                                // selected_place.xml
                                TextView lbl_name = (TextView) findViewById(R.id.name);
                                TextView lbl_address = (TextView) findViewById(R.id.address);
                                TextView lbl_phone = (TextView) findViewById(R.id.phone);
                                TextView lbl_location = (TextView) findViewById(R.id.location);

                                // Check for null data from google
                                // Sometimes place details might missing
                                name = name == null ? "Not present" : name; // if name is null display as "Not present"
                                address = address == null ? "Not present" : address;
                                phone = phone == null ? "Not present" : phone;
                                latitude = latitude == null ? "Not present" : latitude;
                                longitude = longitude == null ? "Not present" : longitude;

                                lbl_name.setText(name);
                                lbl_address.setText(address);
                                lbl_phone.setText(Html.fromHtml("<b>Phone:</b> " + phone));
                                lbl_location.setText(Html.fromHtml("<b>Latitude:</b> " + latitude + ", <b>Longitude:</b> " + longitude));
                            }
                        }
                        else if(status.equals("ZERO_RESULTS")){
                            alert.showAlertDialog(SelectedPlace.this, "Near Places",
                                    "Error no place found.",
                                    false);
                        }
                        else if(status.equals("OVER_QUERY_LIMIT"))
                        {
                            alert.showAlertDialog(SelectedPlace.this, "Places Error",
                                    "Error Occurred - query limit to google places is reached",
                                    false);
                        }
                        else if(status.equals("REQUEST_DENIED"))
                        {
                            alert.showAlertDialog(SelectedPlace.this, "Places Error",
                                    "Error Occurred. Request is denied",
                                    false);
                        }
                        else if(status.equals("INVALID_REQUEST"))
                        {
                            alert.showAlertDialog(SelectedPlace.this, "Places Error",
                                    "Error Occurred. Invalid Request",
                                    false);
                        }
                        else if(status.equals("UNKNOWN_ERROR"))
                        {
                            alert.showAlertDialog(SelectedPlace.this, "Places Error",
                                    "Sorry unknown error Occurred.",
                                    false);
                        }
                        else
                        {
                            alert.showAlertDialog(SelectedPlace.this, "Places Error",
                                    "Error Occurred.",
                                    false);
                        }
                    }else{
                        alert.showAlertDialog(SelectedPlace.this, "Places Error",
                                "Error Occurred.",
                                false);
                    }


                }
            });

        }

    }

}

