//-----------------------------------------------------------------------------
// <auto-generated>
//     This file was generated by the C# SDK Code Generator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//-----------------------------------------------------------------------------


using System;

namespace Unity.Services.Relay.Qos.Http
{
    /// <summary>
    /// Override of Exception class to store the response that triggered the
    /// exception.
    /// </summary>
    [Serializable]
    internal class ResponseDeserializationException : Exception
    {
        /// <summary>The response that triggered the exception.</summary>
        public HttpClientResponse response;

        /// <summary>Default Constructor</summary>
        public ResponseDeserializationException() : base()
        {
        }

        ///<inheritdoc cref="Exception"/>
        public ResponseDeserializationException(string message) : base (message)
        {
        }

        ///<inheritdoc cref="Exception"/>
        ResponseDeserializationException(Exception inner, string message) : base(message, inner)
        {
        }

        /// <summary>Constructor</summary>
        /// <param name="httpClientResponse">The response that triggered the exception.</param>
        public ResponseDeserializationException(HttpClientResponse httpClientResponse) : base(
            "Unable to Deserialize Http Client Response")
        {
            response = httpClientResponse;
        }

        /// <summary>Constructor</summary>
        /// <param name="httpClientResponse">The response that triggered the exception.</param>
        /// <param name="message">Custom error message</param>
        public ResponseDeserializationException(HttpClientResponse httpClientResponse, string message) : base(
            message)
        {
            response = httpClientResponse;
        }

        /// <summary>Constructor</summary>
        /// <param name="httpClientResponse">The response that triggered the exception.</param>
        /// <param name="message">Custom error message</param>
        public ResponseDeserializationException(HttpClientResponse httpClientResponse, Exception inner, string message) : base(
            message, inner)
        {
            this.response = httpClientResponse;
        }
    }
}
