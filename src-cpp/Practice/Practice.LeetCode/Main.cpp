#include <iostream>
#include <vector>

// todo sag move functions to a file RunningSumArray.cpp

std::vector<int> running_sum(std::vector<int>& nums)
{
	if (nums.size() == 1)
		return nums;

	for (auto i{ 1 }; i < nums.size(); i++)
		nums[i] += nums[i - 1];

	return nums;
}

bool test_running_sum()
{
	bool passed = true;

	std::vector<int> case_one{ 1 };
	passed &= running_sum(case_one) == std::vector<int>{ 1 };

	std::vector<int> case_two{ 1,2,3 };
	passed &= running_sum(case_two) == std::vector<int>{1, 3, 6};
	
	return passed;
}

int main()
{
	std::cout << "Running sum 1D array passed: " << test_running_sum() << std::endl;
}
