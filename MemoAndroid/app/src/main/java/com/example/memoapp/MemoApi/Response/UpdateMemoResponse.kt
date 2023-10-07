package com.example.memoapp.MemoApi.Response

class UpdateMemoResponse : ResponseBase() {
    lateinit var ID: String
    lateinit var Title: String
    lateinit var Content: String
}