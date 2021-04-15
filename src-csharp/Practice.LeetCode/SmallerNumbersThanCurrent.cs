namespace Practice.LeetCode
{
    public class SmallerNumbersThanCurrent
    {
        public int[] RunSimple(int[] nums)
        {
            var counts = new int[nums.Length];
            
            for(int i=0; i < nums.Length; i++)
                for(int j=0; j < nums.Length; j++)
                    if (nums[j] < nums[i])
                        counts[i]++;

            return counts;
        }
    }
}