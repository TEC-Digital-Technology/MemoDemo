package com.example.memoapp.MemoApi.Response

class GetMemoResponse : ResponseBase() {
    lateinit var ID: String
    lateinit var Title: String
    lateinit var Content: String
}