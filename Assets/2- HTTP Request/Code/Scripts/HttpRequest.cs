using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;

namespace _2__HTTP_Request.Code.Scripts
{
    public class HttpRequest : MonoBehaviour
{
    // API URLs
    private string apiUrlGet = "https://jsonplaceholder.typicode.com/users/1";
    private string apiUrlPost = "https://jsonplaceholder.typicode.com/posts";

    /// <summary>
    /// Sends a GET request to the API and returns the JSON response as a string.
    /// </summary>
    public async Task<string> WebRequestGet()
    {
        using var request = UnityWebRequest.Get(apiUrlGet);

        // Send the request and wait asynchronously
        var operation = request.SendWebRequest();
        while (!operation.isDone)
            await Task.Yield();

        // Check if request was successful
        if (request.result == UnityWebRequest.Result.Success)
        {
            string jsonResponse = request.downloadHandler.text;
            return jsonResponse;
        }
        else
        {
            Debug.LogError($"GET Request Failed: {request.error}");
            return null;
        }
    }

    /// <summary>
    /// Sends a POST request with form parameters and returns the JSON response as a string.
    /// </summary>
    public async Task<string> WebRequestPost()
    {
        // Create form and add fields
        WWWForm form = new WWWForm();
        form.AddField("userId", "1");
        form.AddField("title", "foo");

        using var request = UnityWebRequest.Post(apiUrlPost, form);

        // Send the request and wait asynchronously
        var operation = request.SendWebRequest();
        while (!operation.isDone)
            await Task.Yield();

        // Check if request was successful
        if (request.result == UnityWebRequest.Result.Success)
        {
            string jsonResponse = request.downloadHandler.text;
            return jsonResponse;
        }
        else
        {
            Debug.LogError($"POST Request Failed: {request.error}");
            return null;
        }
    }
}
}