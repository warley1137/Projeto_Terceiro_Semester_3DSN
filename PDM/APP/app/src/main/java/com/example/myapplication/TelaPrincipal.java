package com.example.myapplication;

import androidx.appcompat.app.AppCompatActivity;

import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;

import com.example.myapplication.databinding.ActivityTelaInicialBinding;

public class TelaPrincipal extends AppCompatActivity {
    private ActivityTelaInicialBinding binding;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_tela_principal);
        Button bt_deslogar = findViewById(R.id.bt_deslogar);
        bt_deslogar.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                Intent principal = new Intent(TelaPrincipal.this, formLogin.class);
                startActivity(principal);
            }
        });
    }
}