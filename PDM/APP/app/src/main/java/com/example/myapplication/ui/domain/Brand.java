package com.example.myapplication.ui.domain;

public class Brand {
    private String label;
    private String logo;

    public Brand(String label, String logo) {
        this.label = label;
        this.logo = logo;
    }

    public String getLabel() {
        return label;
    }

    public void setLabel(String label) {
        this.label = label;
    }

    public String getLogo() {
        return logo;
    }

    public void setLogo(String logo) {
        this.logo = logo;
    }
}

