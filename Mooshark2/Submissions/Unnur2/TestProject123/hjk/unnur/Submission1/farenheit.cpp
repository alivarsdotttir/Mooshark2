//This program converts degrees N celsius to degrees farenheit and prints every degree celsius from 0 to N, in both celsius and farenheit.

#include <iostream>
using namespace std;

double computeFarenheit(int celsius_count, double celsius_max);

int main()
{
    double celsius_max, farenheit;
    cout << "Input maximum celsius: ";
    cin >> celsius_max;

     for (int celsius_count = 0; celsius_count <= celsius_max; celsius_count++)
    {
    farenheit = computeFarenheit(celsius_count, celsius_max);
    cout << celsius_count << " " << farenheit << endl;
    }
    return 0;
}

double computeFarenheit(int celsius_count, double celsius_max)
{
    double farenheit = celsius_count * 1.8 + 32;
    return farenheit;
}
