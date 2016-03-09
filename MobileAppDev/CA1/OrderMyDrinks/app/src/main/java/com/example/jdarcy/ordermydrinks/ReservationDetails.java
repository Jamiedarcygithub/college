package com.example.jdarcy.ordermydrinks;

/**
 * Created by jdarcy on 05/03/2016.
 * Activity class to handle Reserve class
 */

import android.app.Activity;
import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.Spinner;
import android.widget.Toast;

public class ReservationDetails extends Activity {

    Button selectDrinksButton;

    @Override
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.reservation_details);

        selectDrinksButton = (Button) findViewById(R.id.brn_select_drinks);
        selectDrinksButton.setOnClickListener(new View.OnClickListener() {
            public void onClick(View v) {
                selectDrinks();
            }

        });

     }
    public void selectDrinks() {


        final EditText nameField = (EditText) findViewById(R.id.EditTextName);
        String name = nameField.getText().toString();

        final EditText emailField = (EditText) findViewById(R.id.EditTextEmail);
        String email = emailField.getText().toString();

        final Spinner transportTypeSpinner = (Spinner) findViewById(R.id.SpinnerTransportType);
        String transportType = transportTypeSpinner.getSelectedItem().toString();

        Toast.makeText(this, name + email + transportType + " clicked !!!!!", Toast.LENGTH_SHORT).show();


        //define a new Intent for the SelectDrink activity
        Intent intent = new Intent(getApplicationContext(),SelectDrinks.class);
        try {
            //Launch the Reservation details Activity
            startActivity(intent);
        } catch (android.content.ActivityNotFoundException ex) {
            Toast.makeText(getApplicationContext(), "yourActivity is not founded", Toast.LENGTH_SHORT).show();
        }

    }
}
