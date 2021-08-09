﻿using System;
using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Views;
using AndroidX.AppCompat.Widget;
using AndroidX.AppCompat.App;
using Google.Android.Material.FloatingActionButton;
using Google.Android.Material.Snackbar;


namespace TipCalculator
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        Android.Widget.EditText inputBill;
        Android.Widget.Button calculateButton;
        Android.Widget.TextView outputTip;
        Android.Widget.TextView outputTotal;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.activity_main);

            Toolbar toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);
            inputBill = (Android.Widget.EditText)FindViewById(Resource.Id.inputBill);
            outputTip = (Android.Widget.TextView)FindViewById(Resource.Id.outputTip);
            outputTotal = (Android.Widget.TextView)FindViewById(Resource.Id.outputTotal);
            calculateButton = (Android.Widget.Button)FindViewById(Resource.Id.caluculateButton);
            calculateButton.Click += OnCalculateClick;

           
           
        }
        void OnCalculateClick(object sender, EventArgs e)
        {
            string text = inputBill.Text;
            double bill = 0;
            if (double.TryParse(text, out bill))
            {
                var tip = bill * 0.15;
                var total = bill + tip;

                outputTip.Text = tip.ToString();
                outputTotal.Text = total.ToString();
            }


        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.menu_main, menu);
            return true;
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            int id = item.ItemId;
            if (id == Resource.Id.action_settings)
            {
                return true;
            }

            return base.OnOptionsItemSelected(item);
        }

       

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
	}
}
