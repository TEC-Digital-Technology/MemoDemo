package com.example.memoapp.MemoApi.Response

class AddMemoResponse: ResponseBase() {
  lateinit var ID: String
  lateinit var Title: String
  lateinit var Content: String
}