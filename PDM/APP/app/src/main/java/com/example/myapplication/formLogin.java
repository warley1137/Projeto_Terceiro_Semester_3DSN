package com.example.myapplication;

import androidx.appcompat.app.AppCompatActivity;

import android.content.Intent;
import android.content.SharedPreferences;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.TextView;
import android.widget.Toast;

public class formLogin extends AppCompatActivity {

    private TextView text_tela_cadastro;
    private EditText edit_email;
    private EditText edit_senha;
    private Button bt_entrar;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_form_login);
        text_tela_cadastro = findViewById(R.id.text_tela_cadastro);
        text_tela_cadastro.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {

                Intent intent = new Intent(formLogin.this, form_cadastro.class);
                startActivity(intent);
            }
        });
        edit_email= findViewById(R.id.edit_email);
        edit_senha= findViewById(R.id.edit_senha);
        bt_entrar= findViewById(R.id.bt_entrar);

        bt_entrar.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                //Recuperar os valores gravados
                SharedPreferences ler = getSharedPreferences("usuario", MODE_PRIVATE);
                String nome = ler.getString("nome", "");
                String email = ler.getString("email", "");
                int senha = ler.getInt("senha", 0);

                if (edit_email.getText().toString().equals(email) && edit_senha.getText().toString().equals(senha + "")){
                    Toast.makeText(formLogin.this, "Login efetuado com sucesso", Toast.LENGTH_SHORT).show();

                    Intent inicial = new Intent(formLogin.this, TelaInicial.class);
                    startActivity(inicial);
                }else {
                    Toast.makeText(formLogin.this, "Email ou senha invalido", Toast.LENGTH_SHORT).show();
                }

            }
        });


    }
}