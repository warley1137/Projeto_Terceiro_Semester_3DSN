package com.example.myapplication.ui.domain;

public class Rate {
    private float stars;
    private int numComments;

    public Rate(float stars, int numComments) {
        this.stars = stars;
        this.numComments = numComments;
    }

    public String getNumCommentsLabel() {
        return String.format("(%d)", numComments);
    }
}

