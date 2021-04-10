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

std::vector<bool> kids_with_candies(std::vector<int>& candies, int extra_candies)
{
	int max_candies = 1; // constraint 1 <= candies[i] <= 100

	for (int candy : candies)
		if (candy > max_candies)
			max_candies = candy;

	std::vector<bool> can_have_most_candies(candies.size());

	for (int i{ 0 }; i < can_have_most_candies.size(); i++)
		can_have_most_candies[i] = (candies[i] + extra_candies) >= max_candies;

	return can_have_most_candies;
}

bool test_kids_with_candies()
{
	bool passed = true;

	std::vector<int> case_one{1};
	passed &= kids_with_candies(case_one, 1) == std::vector<bool>{ true };

	std::vector<int> case_two{2, 3, 5, 1, 3};
	passed &= kids_with_candies(case_two, 3) == std::vector<bool>{true, true, true, false, true};

	return passed;
}

int maximum_wealth(std::vector<std::vector<int>>& accounts)
{
	int max_wealth{ 0 };

	for (auto account : accounts)
	{
		int wealth{ 0 };
		
		for (int i{ 0 }; i < account.size(); i++)
			wealth += account[i];

		if (wealth > max_wealth)
			max_wealth = wealth;
	}

	return max_wealth;
}

std::vector<int> shuffle(std::vector<int>& nums, int n) {
	std::vector<int>shuffled(2 * n);

	for(int i{0}; i < n; i++)
	{
		shuffled[2 * i] = nums[i];
		shuffled[2 * i + 1] = nums[n + i];
	}

	return shuffled;
}

int num_identical_pairs(std::vector<int>& nums)
{
	int count{ 0 };
	
	for(int i{0}; i < nums.size(); i++)
		for (int j{ i + 1 }; j < nums.size(); j++)
			if (nums[i] == nums[j])
				count++;

	return count;
}

std::string to_string(bool b)
{
	return b ? "true" : "false";
}

int main()
{
	std::cout << "Tests running sum 1D array passed: " << to_string(test_running_sum()) << std::endl;
	std::cout << "Tests defanging IP address passed: " << to_string(test_defang_ip_addr()) << std::endl;
	std::cout << "Tests kids with candies passed: " << to_string(test_kids_with_candies()) << std::endl;
}
