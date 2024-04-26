package com.example.myapplication;

import androidx.appcompat.app.AppCompatActivity;

import android.content.SharedPreferences;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.Toast;

public class form_cadastro extends AppCompatActivity {

public  class Usuario{

    public Usuario(String nome, String email, String senha) {
        this.nome = nome;
        this.email = email;
        this.senha = senha;
    }
    private String nome;
    private  String email;
    private  String senha;
}
    private EditText edit_nome;
    private EditText edit_email;
    private EditText edit_senha;
    private Button bt_cadastrar;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_form_cadastro);
    //indentifiquei cada campo
        edit_nome= findViewById(R.id.edit_nome);
        edit_email= findViewById(R.id.edit_email);
        edit_senha= findViewById(R.id.edit_senha);
        bt_cadastrar= findViewById(R.id.bt_cadastrar);

        bt_cadastrar.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                // Campos que serão coletado os dados do cadastro
                String nome = edit_nome.getText().toString();
                String email = edit_email.getText().toString();
                String senha = edit_senha.getText().toString();

                if (!nome.isEmpty() && !email.isEmpty() && !senha.isEmpty()) {

                    //Para gravar valores em um arquivo
                    SharedPreferences.Editor gravar = getSharedPreferences("usuario", MODE_PRIVATE).edit();
                    gravar.putString("nome", nome);
                    gravar.putString("email", email);
                    gravar.putInt("senha", Integer.parseInt(senha));
                    gravar.commit();

                    Toast.makeText(form_cadastro.this, "Cadastro efetuado com sucesso", Toast.LENGTH_SHORT).show();
                    finish();
                }else {
                    Toast.makeText(form_cadastro.this, "Cadastro não efetuado", Toast.LENGTH_SHORT).show();
                }

            }
        });

    }
}

