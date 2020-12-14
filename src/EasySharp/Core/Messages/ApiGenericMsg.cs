using EasySharp.Core.Messages.Response;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace EasySharp.Core.Messages
{
    public static class ApiGenericMsg
    {
        /// <summary>
        /// Return server error message
        /// </summary>
        public static string ServerError => "Server Error Occurred";

        /// <summary>
        /// Return processing error message
        /// </summary>
        public static string ProcessingError =>
            "An error occured while processing your request. Contact your administrator";

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TBody"></typeparam>
        /// <param name="tbody"></param>
        /// <param name="EntityName"></param>
        /// <returns></returns>
        public static ApiGenericResponse<TBody> OnEntityCreateError<TBody>(TBody tbody, string EntityName)
        {
            return new ApiGenericResponse<TBody>()
            {
                Status = 0,
                Message = $"An error occured while creating new {EntityName}. Contact your administrator.",
                Data = tbody
            };
        }


        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TBody"></typeparam>
        /// <param name="tbody"></param>
        /// <param name="EntityName"></param>
        /// <returns></returns>
        public static ApiGenericResponse<TBody> OnEntityCreateSuccess<TBody>(TBody tbody, string EntityName)
        {
            return new ApiGenericResponse<TBody>()
            {
                Status = (int)HttpStatusCode.OK,
                Message = $"New {EntityName} Created Successfully.",
                Data = tbody
            };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TBody"></typeparam>
        /// <param name="tbody"></param>
        /// <param name="EntityName"></param>
        /// <returns></returns>
        public static ApiGenericResponse<TBody> OnEntityUpdateSuccess<TBody>(TBody tbody, string EntityName)
        {
            return new ApiGenericResponse<TBody>()
            {
                Status = (int)HttpStatusCode.OK,
                Message = $"{EntityName} Updated Successfully.",
                Data = tbody
            };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TBody"></typeparam>
        /// <param name="tbody"></param>
        /// <param name="EntityName"></param>
        /// <returns></returns>
        public static ApiGenericResponse<TBody> OnEntityUpdateError<TBody>(TBody tbody, string EntityName)
        {
            return new ApiGenericResponse<TBody>()
            {
                Status = 0,
                Message = $"An error occured while delteting {EntityName}. Contact your administrator.",
                Data = tbody
            };
        }


        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TBody"></typeparam>
        /// <param name="tbody"></param>
        /// <param name="EntityName"></param>
        /// <returns></returns>
        public static ApiGenericResponse<TBody> OnEntityDeleteSuccess<TBody>(TBody tbody, string EntityName)
        {
            return new ApiGenericResponse<TBody>()
            {
                Status = (int)HttpStatusCode.OK,
                Message = $"{EntityName} Deleted Successfully.",
                Data = tbody
            };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TBody"></typeparam>
        /// <param name="tbody"></param>
        /// <param name="EntityName"></param>
        /// <returns></returns>
        public static ApiGenericResponse<TBody> OnEntityDeleteError<TBody>(TBody tbody, string EntityName) 
        {
            return new ApiGenericResponse<TBody>()
            {
                Status = 0,
                Message = $"An error occured while delteting {EntityName}. Contact your administrator.",
                Data = tbody
            };
        }
    }
}
