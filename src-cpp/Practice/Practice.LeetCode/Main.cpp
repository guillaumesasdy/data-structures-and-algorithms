#include <iostream>
#include <vector>

// todo sag move function running_sum to a specific file

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

// todo sag move function defang_ip_addr to a specific file

std::string defang_ip_addr(std::string address)
{
	std::vector<char> defanged(address.size() + 6); // 6 extra chars to store the [] repeated 3 times

	int defanged_index{ 0 };	
	for(int address_index{0}; address_index < address.size(); address_index++)
	{
		if (address[address_index] == '.')
		{
			defanged[defanged_index++] = '[';
			defanged[defanged_index++] = '.';
			defanged[defanged_index++] = ']';
		}
		else defanged[defanged_index++] = address[address_index];
	}
	
	return std::string(defanged.begin(), defanged.end());
}

bool test_defang_ip_addr()
{
	bool passed = true;

	passed &= defang_ip_addr("1.1.1.1") == "1[.]1[.]1[.]1";
	passed &= defang_ip_addr("1.10.100.1") == "1[.]10[.]100[.]1";

	return passed;
}

std::string to_string(bool b)
{
	return b ? "true" : "false";
}

int main()
{
	std::cout << "Tests running sum 1D array passed: " << to_string(test_running_sum()) << std::endl;
	std::cout << "Tests defanging IP address passed: " << to_string(test_defang_ip_addr()) << std::endl;
}
