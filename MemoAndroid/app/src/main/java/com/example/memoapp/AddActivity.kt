package com.example.memoapp

import android.content.Intent
import android.os.Bundle
import android.widget.Toast
import androidx.appcompat.app.AppCompatActivity
import com.example.memoapp.MemoApi.MemoApiUtils
import com.example.memoapp.MemoApi.Request.AddMemoRequest
import com.example.memoapp.databinding.AddActivityBinding
import com.example.memoapp.databinding.EditActivityBinding

class AddActivity : AppCompatActivity() {

    private lateinit var binding: AddActivityBinding

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        binding = AddActivityBinding.inflate(layoutInflater)
        setContentView(binding.root)

        binding.btnAdd.setOnClickListener {
            if (binding.editTitle.text.toString().isBlank()
                || binding.editContent.text.toString().isBlank()
            ) {
                Toast.makeText(this, "標題或內容不得為空", Toast.LENGTH_SHORT).show()
                return@setOnClickListener
            }
            MemoApiUtils.addMemo(
                AddMemoRequest(
                    binding.editTitle.text.toString(),
                    binding.editContent.text.toString()
                ), result = {
                    runOnUiThread {
                        Toast.makeText(this, "Success", Toast.LENGTH_SHORT).show()
                        startActivity(Intent(this, MainActivity::class.java))
                        finish()
                    }
                }, error = {
                    runOnUiThread {
                        Toast.makeText(this, it, Toast.LENGTH_SHORT).show()
                    }
                })
        }

    }

}