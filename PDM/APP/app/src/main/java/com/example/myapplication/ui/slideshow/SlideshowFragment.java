package com.example.myapplication.ui.slideshow;

import static android.app.Activity.RESULT_OK;

import android.annotation.SuppressLint;
import android.app.Activity;
import android.content.Intent;
import android.graphics.Bitmap;
import android.os.Bundle;
import android.provider.MediaStore;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.Button;
import android.widget.ImageView;

import androidx.activity.result.ActivityResult;
import androidx.activity.result.ActivityResultCallback;
import androidx.activity.result.ActivityResultLauncher;
import androidx.activity.result.contract.ActivityResultContracts;
import androidx.fragment.app.Fragment;

import com.example.myapplication.R;

public class SlideshowFragment extends Fragment {

    private static final int REQUEST_IMAGE_CAPTURE = 101;
    private ImageView imageView;
    View root;

    @SuppressLint("MissingInflatedId")
    public View onCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState) {
        root = inflater.inflate(R.layout.fragment_slideshow, container, false);

        imageView = root.findViewById(R.id.imageView2); // Certifique-se de que o ImageView tenha o ID correto

        Button captureButton = root.findViewById(R.id.bt_foto); // Certifique-se de que o botão tenha o ID correto
        captureButton.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
//                dispatchTakePictureIntent();
//                Abre a câmera
                Intent it = new Intent(MediaStore.ACTION_IMAGE_CAPTURE);
//                Precisamos indicar que irá abrir a câmera, aguarda tirar a foto e recuperar a foto depois
                recuperaFoto.launch(it); // Método para indicar o que será feito depois que a foto voltar ao nosso aplicativo
            }
        });
        return root;
    }
//    Código que será utilizado quando a foto "voltar" da câmera
    ActivityResultLauncher<Intent> recuperaFoto = registerForActivityResult(
        new ActivityResultContracts.StartActivityForResult(), new ActivityResultCallback<ActivityResult>() {
            @Override
            public void onActivityResult(ActivityResult result) {
//                Testar se tem uma foto
                if (result.getResultCode() == RESULT_OK) {
//                    Recuperar a foto
                    Bitmap fotografia = (Bitmap) result.getData().getExtras().get("data");
//                    Acessar o ImageView

                    ImageView imgFotografia = root.findViewById(R.id.imageView2);
//                    Colocar a foto no ImageView
                    imgFotografia.setImageBitmap(fotografia);
//                    A maioria dos celulares tira foto em modo paisagem (deitada)
                    imgFotografia.setRotation(0); //Girar 90 graus sentido horário
                }
            }
        }
);

    private void dispatchTakePictureIntent() {
        Intent takePictureIntent = new Intent(MediaStore.ACTION_IMAGE_CAPTURE);
        if (takePictureIntent.resolveActivity(requireActivity().getPackageManager()) != null) {
            startActivityForResult(takePictureIntent, REQUEST_IMAGE_CAPTURE);
        }
    }

    @Override
    public void onActivityResult(int requestCode, int resultCode, Intent data) {
        super.onActivityResult(requestCode, resultCode, data);

        if (requestCode == REQUEST_IMAGE_CAPTURE && resultCode == -1) {
            Bundle extras = data.getExtras();
            Bitmap imageBitmap = (Bitmap) extras.get("data");

            imageView.setImageBitmap(imageBitmap);
        }
    }
}
