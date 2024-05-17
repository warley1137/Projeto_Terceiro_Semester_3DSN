package com.example.myapplication;

import androidx.appcompat.app.AppCompatActivity;

import android.content.Intent;
import android.os.Bundle;
import android.os.Handler;

public class Screen extends AppCompatActivity {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_screen);
        Thread timer = new Thread() {
            public void run() {
                try {
                    sleep(3000); // Tempo de exibição da splash screen em milissegundos (3 segundos neste exemplo)
                } catch (InterruptedException e) {
                    e.printStackTrace();
                } finally {
                    Intent intent = new Intent(Screen.this, TelaMenu.class);
                    startActivity(intent);
                    finish();
                }
            }
        };
        timer.start();

    }
}