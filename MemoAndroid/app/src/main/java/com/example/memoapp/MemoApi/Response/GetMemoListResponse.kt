package com.example.memoapp.MemoApi.Response

class GetMemoListResponse : ResponseBase() {
    inner class MemoInfo {
        lateinit var ID: String
        lateinit var Title: String
        lateinit var Content: String
    }

    lateinit var MemoList: List<MemoInfo>
}