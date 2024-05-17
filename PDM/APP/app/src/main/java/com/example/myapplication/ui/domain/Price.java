package com.example.myapplication.ui.domain;

import android.content.Context;

import com.example.myapplication.R;

import java.util.Locale;

public class Price {
    private float normal; // Preço normal
    private int parcels;
    private boolean hasDiscount;
    private float withDiscount; // Preço com o desconto já aplicado

    public Price(float normal, int parcels, boolean hasDiscount, float withDiscount) {
        this.normal = normal;
        this.parcels = parcels;
        this.hasDiscount = hasDiscount;
        this.withDiscount = withDiscount;
    }

    public String getNormalLabel(Context context) {
        return String.format(
                Locale.GERMAN,
                "%s %.2f",
                context.getString(R.string.money_sign), normal);
    }

    public String getWithDiscountLabel(Context context) {
        return String.format(
                Locale.GERMAN,
                "%s %.2f",
                context.getString(R.string.money_sign), withDiscount);
    }

    public String getPercentDiscountLabel() {
        float percent = ((normal - withDiscount) / normal) * 100;
        return String.format("-%d%%", (int) percent);
    }

    public String getParcelsLabel(Context context) {
        float priceParcel = hasDiscount ? withDiscount / parcels : normal / parcels;
        return String.format(Locale.GERMAN, "%s %dx %s %s %.2f",
                context.getString(R.string.in_until),
                parcels,
                context.getString(R.string.of),
                context.getString(R.string.money_sign),
                priceParcel);
    }
}
