package com.example.memoapp

import android.os.Bundle
import androidx.appcompat.app.AppCompatActivity
import com.example.memoapp.databinding.EditActivityBinding

class EditActivity : AppCompatActivity() {

    private lateinit var binding: EditActivityBinding

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        binding = EditActivityBinding.inflate(layoutInflater)
        setContentView(binding.root)
    }

}