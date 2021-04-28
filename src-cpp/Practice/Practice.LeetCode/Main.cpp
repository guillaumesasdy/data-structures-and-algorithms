#include <iostream>
#include <vector>
#include <array>
#include <cmath>

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

int num_jewels_in_stones(std::string jewels, std::string stones)
{
	auto nb_jewels{ 0 };
	
	std::array<char, 128> stones_counter{};
	for (auto c : stones)
		stones_counter[static_cast<int>(c)]++;

	for (auto c : jewels)
		nb_jewels += stones_counter[static_cast<int>(c)];

	return nb_jewels;
}

std::vector<int> smaller_numbers_than_current(std::vector<int>& nums)
{
	std::vector<int> counts(nums.size());
	
	for (int i{ 0 }; i < nums.size(); i++)
		for (int j{ 0 }; j < nums.size(); j++)
			if (nums[j] < nums[i])
				counts[i]++;

	return counts;
}

void smaller_numbers_than_current_faster_sub(
	std::vector<int>& nums,
	std::vector<int>& counter,
	std::vector<int>& sub_indexes,
	int bit_offset)
{
	if (bit_offset < 0 || sub_indexes.size() <= 1)
		return;
	
	const int bit_comparison{ 1 << bit_offset };
	
	std::vector<int> match_indexes(0);
	std::vector<int> left_indexes(0);

	for (auto index : sub_indexes)
		if ((nums[index] & bit_comparison) != 0)
			match_indexes.push_back(index);
		else
			left_indexes.push_back(index);

	if (left_indexes.empty())
	{
		smaller_numbers_than_current_faster_sub(nums, counter, sub_indexes, bit_offset - 1);
		return;
	}

	for (auto index : match_indexes)
		counter[index] += left_indexes.size();

	smaller_numbers_than_current_faster_sub(nums, counter, left_indexes, bit_offset - 1);
	smaller_numbers_than_current_faster_sub(nums, counter, match_indexes, bit_offset - 1);
}

std::vector<int> smaller_numbers_than_current_faster(std::vector<int>& nums)
{
	const int bit_offset{ 6 }; // max value 100 decimal, eq. to 1100100 binary, the highest bit is 7th, thus 6 offset from the first
	std::vector<int> counter(nums.size());

	std::vector<int> indexes(nums.size());
	for (int i{ 0 }; i < indexes.size(); i++)
		indexes[i] = i;

	smaller_numbers_than_current_faster_sub(nums, counter, indexes, bit_offset);

	return counter;
}

bool test_smaller_numbers_than_current_faster()
{
	bool passed = true;

	std::vector<int> case_one{2, 1, 4};
	passed &= smaller_numbers_than_current_faster(case_one) == std::vector<int>{1, 0, 2};

	std::vector<int> case_two{ 2, 2, 1, 4, 4 };
	passed &= smaller_numbers_than_current_faster(case_two) == std::vector<int>{1, 1, 0, 3, 3};

	std::vector<int> case_three{ 100, 99, 98, 90, 91, 92, 93, 94 };
	passed &= smaller_numbers_than_current_faster(case_three) == std::vector<int>{7, 6, 5, 0, 1, 2, 3, 4};

	return passed;
}

int array_sign(std::vector<int>& nums)
{
	int sign{1};

	for (auto num : nums)
	{
		if (num == 0)
			return 0;

		if (num < 0)
			sign *= -1;
	}

	return sign;
}

std::string shuffle_string(std::string s, std::vector<int>& indices)
{
	std::vector<char> shuffled(s.size());

	for (auto i{0}; i < s.size(); i++)
	{
		shuffled[indices[i]] = s[i];
	}

	std::string shuffled_string(shuffled.begin(), shuffled.end());
	
	return shuffled_string;
}

double compute_distance(std::vector<int>& a, std::vector<int>& b)
{
	const auto x_diff = std::pow(a[0] - b[0], 2);
	const auto y_diff = std::pow(a[1] - b[1], 2);
	
	return std::sqrt(x_diff + y_diff);
}

std::vector<int> count_points_in_circles_by_distance(
	std::vector<std::vector<int>>& points, 
	std::vector<std::vector<int>>& circles)
{
	std::vector<int> result{};

	for(std::vector<int>& circle : circles)
	{
		std::vector<int> circle_center{circle[0], circle[1]};
		int radius{ circle[2] };
		
		int inside_counter{ 0 };
		for(std::vector<int>& point : points)
		{
			// no need for epsilon below, the precision is covered with test on edge cases
			if (compute_distance(point, circle_center) <= radius)
				inside_counter++;
		}

		result.push_back(inside_counter);
	}

	return result;
}

bool test_count_points_in_circles_by_distance()
{
	bool passed = true;

	std::vector<std::vector<int>> case_one_points
	{
		{1, 3},
		{3, 3},
		{5, 3},
		{2, 2},
	};
	std::vector<std::vector<int>> case_one_circles
	{
		{2, 3, 1},
		{4, 3, 1},
		{1, 1, 2}
	};
	std::vector<int> case_one_result_expected{3, 2, 2};
	passed &= count_points_in_circles_by_distance(case_one_points, case_one_circles) == case_one_result_expected;

	std::vector<std::vector<int>> case_two_points // one point for each edge cases: bottom left, top left, top right, bottom right
	{
		{0, 0},
		{0, 500},
		{500, 500},
		{500, 0},
	};
	std::vector<std::vector<int>> case_two_circles
	{
		{250, 250, 500},
		{0, 0, 500},
		{0, 0, 499},
		{0, 250, 250},
		{0, 250, 249},
		/* ... */
		{500, 500, 500},
		{250, 500, 250},
		{250, 500, 249}
	};
	std::vector<int> case_two_result_expected{ 4, 3, 1, 2, 0, /* ... */ 3, 2, 0};
	passed &= count_points_in_circles_by_distance(case_two_points, case_two_circles) == case_two_result_expected;

	return passed;
}

std::vector<int> count_points_in_circles_with_map(
	std::vector<std::vector<int>>& points,
	std::vector<std::vector<int>>& circles)
{
	const size_t map_size{ 501 };

	std::vector<int> result; // todo

	return result;
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
	std::cout << "Tests smaller numbers than current: " << to_string(test_smaller_numbers_than_current_faster()) << std::endl;
	std::cout << "Tests count points in circle by distance: " << to_string(test_count_points_in_circles_by_distance()) << std::endl;
}
