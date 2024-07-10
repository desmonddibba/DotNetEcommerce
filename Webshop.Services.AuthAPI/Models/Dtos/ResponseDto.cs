﻿namespace Webshop.Services.AuthAPI.Models.Dtos
{
	public class ResponseDto
	{
        public object? Result { get; set; }
		public bool IsSuccess { get; set; } = true;
		public string Message { get; set; } = "";
	}
}
