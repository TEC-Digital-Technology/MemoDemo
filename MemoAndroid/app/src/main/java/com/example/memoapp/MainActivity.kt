package com.example.memoapp

import android.content.Intent
import androidx.appcompat.app.AppCompatActivity
import android.os.Bundle
import android.view.View
import android.view.ViewGroup
import android.widget.BaseAdapter
import android.widget.Toast
import com.example.memoapp.MemoApi.MemoApiUtils
import com.example.memoapp.MemoApi.Request.DeleteMemoRequest
import com.example.memoapp.MemoApi.Request.GetMemoListRequest
import com.example.memoapp.MemoApi.Response.GetMemoListResponse
import com.example.memoapp.databinding.ActivityMainBinding
import com.example.memoapp.databinding.ItemMemoListBinding

class MainActivity : AppCompatActivity() {

    private lateinit var binding: ActivityMainBinding
    private lateinit var memoData: List<GetMemoListResponse.MemoInfo>

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        binding = ActivityMainBinding.inflate(layoutInflater)
        setContentView(binding.root)

        MemoApiUtils.getMemoList(GetMemoListRequest(), result = {
            runOnUiThread {
                binding.listView.adapter = object : BaseAdapter() {
                    override fun getCount(): Int {
                        return it.MemoList.size
                    }

                    override fun getItem(p0: Int): Any {
                        return it.MemoList.get(p0)
                    }

                    override fun getItemId(p0: Int): Long {
                        return p0.toLong()
                    }

                    override fun getView(p0: Int, p1: View?, p2: ViewGroup?): View {
                        val itemBinding = ItemMemoListBinding.inflate(layoutInflater, p2, false)
                        itemBinding.title.text = it.MemoList.get(p0).Title
                        return itemBinding.root
                    }
                }
                memoData = it.MemoList
            }
        }, error = {
            runOnUiThread {
                Toast.makeText(this, it, Toast.LENGTH_SHORT).show()
            }
        })

        binding.btnAdd.setOnClickListener {
            startActivity(Intent(this, AddActivity::class.java))
            finish()
        }

        binding.listView.setOnItemClickListener { adapterView, view, i, l ->
            val intent = Intent(this, EditActivity::class.java)
            intent.putExtra("MemoID", memoData.get(i).ID)
            startActivity(intent)
            finish()
        }

        binding.listView.setOnItemLongClickListener { adapterView, view, i, l ->
            MemoApiUtils.deleteMemo(DeleteMemoRequest(memoData.get(i).ID), result = {
                runOnUiThread {
                    Toast.makeText(this, "Success", Toast.LENGTH_SHORT).show()
                    startActivity(intent)
                    finish()
                }
            }, error = {
                runOnUiThread {
                    Toast.makeText(this, it, Toast.LENGTH_SHORT).show()
                }
            })
            return@setOnItemLongClickListener true
        }


    }
}