namespace Assignment8_Inheritance_Overloading_Constructors.Modelsl;

internal class NotificationService
{
    public string Send(string emailAddress, string message)
    {
        return $"Sending email to {emailAddress} with message: {message}";
    }

    public string Send(string phoneNumber)
    {
        return $"Sending SMS to {phoneNumber} with default message: 'Please check your account.'";
    }

    public string Send(string phoneNumber, int smsCode)
    {
        return $"Sending SMS to {phoneNumber} with verification code: {smsCode}";
    }
}
