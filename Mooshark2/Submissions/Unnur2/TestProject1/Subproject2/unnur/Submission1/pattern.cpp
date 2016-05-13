/*This program reads an integer N from the keyboard and outputs N lines
with N stars in the first line, counting down to 1 star per line.*/

#include <iostream>
using namespace std;

int main()
{
    int N, line, column;
    cout << "Input an integer: ";
    cin >> N;
    cout << endl;

    for (line = N; line >= 1; line--)
    {
        for(column =1; column <= line; column++)
        {
            cout<<"*";
        }
          cout << endl;
    }

    return 0;
}
