﻿namespace TimeTableProject.Dto
{
    public class SuccessResponse
    {
        public string Message { get; set; }

        public SuccessResponse(string message) {
            Message = message;
        }
    }
}
