#include <iostream>
using namespace std;

bool primeNumber(int number)
{
    if(number <= 1)
    {
        return false;
    }

    bool ok = true;
    for(int i = 2 ; i < number ; i++)
    {
        if(number % i == 0)
        {
            ok = false;
        }
    }

    return ok;
}

int main()
{
    int a, b;
    cin >> a >> b;
    for(int i = a ; i <= b ; i++)
    {
        if(primeNumber(i))
        {
            cout << i << endl;
        }
    }

    return 0;
}

