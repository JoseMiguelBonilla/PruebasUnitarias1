using System.Text;
using Xunit;

namespace PruebasUnitarias1;

public class UnitTest1
{
    [Fact]
    public void IsPasswordSecure_returns_false_if_password_has_less_than_8_characters()
    {
        //Arrange
        var registerViewModel = new RegisterViewModel();

        //Act
        bool result = registerViewModel.IsPasswordSecure("1234567");

        //Assert
        Assert.False(result);

    }
    [Fact]
    public void IsPasswordSecure_returns_false_if_password_does_not_contains_uppercase_character()
    {
        //Arrange
        var registerViewModel = new RegisterViewModel();

        //Act
        bool result = registerViewModel.IsPasswordSecure("12345678a");

        //Assert
        Assert.False(result);

    }

}

internal class RegisterViewModel
{
    internal bool IsPasswordSecure(string password)
    {
        if (password.Length < 8)
        {
            return false;
        }
        //1234A5678
        if (!ContieneMayuscula(password))
        {
            return false;
        }
        if (!Simbolos(password))
        {
            return false;
        }

            return true;
    }

    private bool ContieneMayuscula(string password)
    {
        char[] passwordChars = password.ToCharArray();
        foreach (char c in passwordChars)
        {
            if (Char.IsLetter(c) && IsUpper(c))
            {
                return true;
            }
        }
        return false;
    }

    private bool IsUpper(char c)
    {
        int codigoAscii = Convert.ToInt32(c);

        return codigoAscii >= 65 && codigoAscii <= 90;

    }

    private bool Simbolos(string password)
    {
        foreach (char caracter in password)
        {
            if (!char.IsLetterOrDigit(caracter))
            {
                return true;
            }
        }
        return false;
    }
}

