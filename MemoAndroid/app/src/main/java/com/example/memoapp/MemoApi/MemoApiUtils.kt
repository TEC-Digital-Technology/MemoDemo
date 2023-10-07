package com.example.memoapp.MemoApi

import com.example.memoapp.MemoApi.Request.AddMemoRequest
import com.example.memoapp.MemoApi.Request.DeleteMemoRequest
import com.example.memoapp.MemoApi.Request.GetMemoListRequest
import com.example.memoapp.MemoApi.Request.GetMemoRequest
import com.example.memoapp.MemoApi.Request.UpdateMemoRequest
import com.example.memoapp.MemoApi.Response.AddMemoResponse
import com.example.memoapp.MemoApi.Response.DeleteMemoResponse
import com.example.memoapp.MemoApi.Response.GetMemoListResponse
import com.example.memoapp.MemoApi.Response.GetMemoResponse
import com.example.memoapp.MemoApi.Response.ResponseBase
import com.example.memoapp.MemoApi.Response.UpdateMemoResponse
import com.google.gson.Gson
import okhttp3.Call
import okhttp3.Callback
import okhttp3.MediaType.Companion.toMediaType
import okhttp3.OkHttpClient
import okhttp3.Request
import okhttp3.RequestBody.Companion.toRequestBody
import okhttp3.Response
import java.io.IOException
import kotlin.jvm.Throws

object MemoApiUtils {
    val baseUrl = "http://10.0.2.2/MemoApi.WebApi/api/Memo/"

    fun getRequest(url: String, body: String): Request {
        return Request.Builder()
            .post(body.toRequestBody("application/json".toMediaType()))
            .url(url)
            .build()
    }

    fun request(request: Request, result: (String, Boolean) -> Unit) {
        OkHttpClient().newCall(request).enqueue(object : Callback {
            override fun onFailure(call: Call, e: IOException) {
                result(e.message.toString(), true)
            }

            override fun onResponse(call: Call, response: Response) {
                val responseString = response.body!!.string()
                if (response.code == 200) {
                    val dataSet =
                        Gson().fromJson(responseString, ResponseBase::class.java)
                    if (dataSet.ResultCode != "0000") {
                        onFailure(call, IOException(Gson().toJson(dataSet)))
                        return
                    }
                    result(responseString, false)
                    return
                }
                onFailure(call, IOException(responseString))
            }
        })
    }

    fun getMemo(request: GetMemoRequest, result : (GetMemoResponse) -> Unit, error : (String) -> Unit){
        request(getRequest("${baseUrl}GetMemo", Gson().toJson(request))){resultString, isError ->
            if(isError){
                error(resultString)
                return@request
            }
            result(Gson().fromJson(resultString, GetMemoResponse::class.java))
        }
    }

    fun getMemoList(request: GetMemoListRequest, result : (GetMemoListResponse) -> Unit, error : (String) -> Unit){
        request(getRequest("${baseUrl}GetMemoList", Gson().toJson(request))){resultString, isError ->
            if(isError){
                error(resultString)
                return@request
            }
            result(Gson().fromJson(resultString, GetMemoListResponse::class.java))
        }
    }

    fun addMemo(request: AddMemoRequest, result : (AddMemoResponse) -> Unit, error : (String) -> Unit){
        request(getRequest("${baseUrl}AddMemo", Gson().toJson(request))){resultString, isError ->
            if(isError){
                error(resultString)
                return@request
            }
            result(Gson().fromJson(resultString, AddMemoResponse::class.java))
        }
    }

    fun updateMemo(request: UpdateMemoRequest, result : (UpdateMemoResponse) -> Unit, error : (String) -> Unit){
        request(getRequest("${baseUrl}UpdateMemo", Gson().toJson(request))){resultString, isError ->
            if(isError){
                error(resultString)
                return@request
            }
            result(Gson().fromJson(resultString, UpdateMemoResponse::class.java))
        }
    }

    fun deleteMemo(request: DeleteMemoRequest, result : (DeleteMemoResponse) -> Unit, error : (String) -> Unit){
        request(getRequest("${baseUrl}DeleteMemo", Gson().toJson(request))){resultString, isError ->
            if(isError){
                error(resultString)
                return@request
            }
            result(Gson().fromJson(resultString, DeleteMemoResponse::class.java))
        }
    }


}