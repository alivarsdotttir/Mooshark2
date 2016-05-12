//This program tells us whether an integer n, and every integer counting down from n to 1, is even or odd.

#include <iostream>
using namespace std;

int main () 
{
	int n;
	
	cin >> n;

		if (n % 2 == 0) 
		{
			cout << "even" << endl;
		}
		else {
			cout << "odd" << endl;
		}
	
	
    return 0;
}
