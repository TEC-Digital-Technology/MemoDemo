package com.example.memoapp

import android.content.Intent
import android.os.Bundle
import android.widget.Toast
import androidx.appcompat.app.AppCompatActivity
import com.example.memoapp.MemoApi.MemoApiUtils
import com.example.memoapp.MemoApi.Request.AddMemoRequest
import com.example.memoapp.MemoApi.Request.GetMemoRequest
import com.example.memoapp.MemoApi.Request.UpdateMemoRequest
import com.example.memoapp.MemoApi.Response.GetMemoResponse
import com.example.memoapp.databinding.EditActivityBinding

class EditActivity : AppCompatActivity() {

    private lateinit var binding: EditActivityBinding
    private lateinit var memoInfo: GetMemoResponse

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        binding = EditActivityBinding.inflate(layoutInflater)
        setContentView(binding.root)

        MemoApiUtils.getMemo(GetMemoRequest(intent.getStringExtra("MemoID")!!), result = {
            memoInfo = it
            runOnUiThread {
                binding.editTitle.setText(it.Title)
                binding.editContent.setText(it.Content)
            }
        }, error = {
            runOnUiThread {
                Toast.makeText(this, it, Toast.LENGTH_SHORT).show()
            }
        })


        binding.btnEdit.setOnClickListener {
            if (binding.editTitle.text.toString().isBlank()
                || binding.editContent.text.toString().isBlank()
            ) {
                Toast.makeText(this, "標題或內容不得為空", Toast.LENGTH_SHORT).show()
                return@setOnClickListener
            }
            MemoApiUtils.updateMemo(
                UpdateMemoRequest(
                    memoInfo.ID,
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