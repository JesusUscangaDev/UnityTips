using UnityEngine;

namespace _2__HTTP_Request.Code.Scripts
{
    using UnityEngine;
    using TMPro; // TextMeshPro namespace
    using System.Threading.Tasks;

    public class UIController : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI textInScreen; // Reference to the UI text
        [SerializeField] private HttpRequest httpRequestClass; // Reference to the HTTP request handler

        /// <summary>
        /// Triggered by a button click to perform a GET request.
        /// Updates the UI with the response.
        /// </summary>
        public async void OnClick_HttpRequestGet()
        {
            try
            {
                string response = await httpRequestClass.WebRequestGet();

                // Update the UI only if response is valid
                textInScreen.text = string.IsNullOrEmpty(response) ? "No response received." : response;
            }
            catch (System.Exception ex)
            {
                Debug.LogError($"GET Request failed: {ex.Message}");
                textInScreen.text = "Error during GET request.";
            }
        }

        /// <summary>
        /// Triggered by a button click to perform a POST request.
        /// Updates the UI with the response.
        /// </summary>
        public async void OnClick_HttpRequestPost()
        {
            try
            {
                string response = await httpRequestClass.WebRequestPost();

                // Update the UI only if response is valid
                textInScreen.text = string.IsNullOrEmpty(response) ? "No response received." : response;
            }
            catch (System.Exception ex)
            {
                Debug.LogError($"POST Request failed: {ex.Message}");
                textInScreen.text = "Error during POST request.";
            }
        }
    }
}