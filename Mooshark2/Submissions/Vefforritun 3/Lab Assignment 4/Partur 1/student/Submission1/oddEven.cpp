//This program tells us whether an integer n, and every integer counting down from n to 1, is even or odd.

#include <iostream>
using namespace std;

int main () 
{
	int n;
	

	cout << "Input n: ";
	cin >> n;
	
	while (n > 0)
	{

	
		if (n % 2 == 0) 
		{
			cout << n << " is even" << endl;
		}
		else {
			cout << n << " is odd " << endl;
		}
	
	n = n-1;
	
	}
	
    return 0;
}
