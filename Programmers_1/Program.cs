using System;
using System.Text;
//StringBuilder 사용

using System.Collections.Generic;
//List, Dictionary, HashSet 사용

using System.Linq;
//List 부속품, Dictionary 부속품, 배열 부속품 사용

using System.Data;
using System.Diagnostics;
//DataTable 사용

namespace Programmers
{
    class Test
    {
        #region 1~10
        //Lv0_달리기 경주_1
        public string[] Solution1(string[] players, string[] callings)
        {
            Dictionary<string, int> dic = new Dictionary<string, int>();

            for (int i = 0; i < players.Length; i++)
                dic.Add(players[i], i);

            int num;
            string temp;

            for (int i = 0; i < callings.Length; i++)
            {
                num = dic[callings[i]]--;
                dic[players[num - 1]]++;

                temp = players[num];
                players[num] = players[num - 1];
                players[num - 1] = temp;
            }

            return players;
        }

        //Lv0_잘라서 배열로 저장하기_2
        public string[] Solution2(string my_str, int n)
        {
            List<string> strList = new List<string>();
            int i = 0;

            for (; i + n < my_str.Length; i += n)
                strList.Add(my_str.Substring(i, n));

            strList.Add(my_str.Substring(i));

            return strList.ToArray();
        }

        //Lv0_문자 개수 세기_3
        public int[] Solution3(string my_string)
        {
            int[] list = new int[52];

            for (int i = 0; i < my_string.Length; i++)
            {
                for (int j = 0; j < 26; j++)
                {
                    if (j + 65 == Convert.ToInt32(my_string[i]))
                    {
                        list[j]++;
                        break;
                    }
                    else if (j + 97 == Convert.ToInt32(my_string[i]))
                    {
                        list[j + 26]++;
                        break;
                    }
                }
            }

            return list;
        }

        //Lv1_부족한 금액 계산하기_4
        public long Solution4(int price, int money, int count)
        {
            long result = 0;

            for (int i = 1; i <= count; i++)
                result += price * i;

            if (0 < money - result)
                result = 0;
            else
                result -= money;

            return result;
        }

        //Lv0_배열 만들기 4_5
        public int[] Solution5(int[] arr)
        {
            List<int> list = new List<int>();

            for (int i = 0; i < arr.Length; i++)
            {
                if (0 == list.Count)
                    list.Add(arr[i]);
                else if (list.Last() < arr[i])
                    list.Add(arr[i]);
                else if (list.Last() >= arr[i])
                {
                    list.RemoveAt(list.Count - 1);
                    i--;
                }
            }

            return list.ToArray();
        }

        //Lv0_공 던지기_6
        public int Solution6(int[] numbers, int k)
        {
            int result = k * 2 - 1;

            while (result > numbers.Length)
                result -= numbers.Length;

            return numbers[result - 1];
        }

        //Lv1_푸드 파이트 대회_7
        public string Solution7(int[] food)
        {
            StringBuilder result = new StringBuilder("0");

            for (int i = food.Length - 1; i >= 0; i--)
            {
                int temp = food[i] / 2;

                for (int j = 0; j < temp; j++)
                {
                    result.Insert(0, i.ToString());
                    result.Append(i.ToString());
                }
            }

            return result.ToString();
        }

        //Lv1_두 개 뽑아서 더하기_8
        public int[] Solution8(int[] numbers)
        {
            List<int> result = new List<int>();

            for (int i = 0; i + 1 < numbers.Length; i++)
                for (int j = i + 1; j < numbers.Length; j++)
                    if (!result.Contains(numbers[i] + numbers[j]))
                        result.Add(numbers[i] + numbers[j]);

            result.Sort();
            return result.ToArray();
        }

        //Lv2_점프와 순간 이동_9
        public int Solution9(int n)
        {
            int result = 0;

            while (n != 0)
            {
                if (n % 2 == 0)
                    n /= 2;
                else
                {
                    n /= 2;
                    result++;
                }
            }

            return result;
        }

        //Lv2_예상 대진표_10
        public int Solution10(int n, int a, int b)
        {
            int result = 0;

            while (a != b)
            {
                a = a / 2 + a % 2;
                b = b / 2 + b % 2;
                result++;
            }

            return result;
        }
        #endregion

        #region 11~20
        //Lv1_콜라 문제_11
        public int Solution11(int a, int b, int n)
        {
            int result = 0;

            while (n >= a)
            {
                result += n / a * b;
                n = n / a * b + n % a;
            }

            return result;
        }

        //Lv2_N개의 최소공배수_12
        public int Solution12(int[] arr)
        {
            int temp = arr[arr.Length - 1];

            while (true)
            {
                bool b = true;

                for (int i = 0; i < arr.Length - 1; i++)
                {
                    if (temp % arr[i] == 0)
                    {
                        b = true;
                        continue;
                    }

                    b = false;
                    temp += arr[arr.Length - 1];
                    break;
                }

                if (b)
                    break;
            }

            return temp;
        }

        //Lv0_문자열 출력하기_13
        public void Solution13()
        {
            String s;

            Console.Clear();
            s = Console.ReadLine();

            Console.WriteLine(s);
        }

        //Lv0_최빈값 구하기_14
        public int Solution14(int[] array)
        {
            Dictionary<int, int> dic = new Dictionary<int, int>();

            foreach (int i in array)
            {
                if (dic.ContainsKey(i))
                    dic[i]++;
                else
                    dic[i] = 1;
            }

            dic = dic.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, x => x.Value); //value값 기준으로 내림차순 정렬

            int result = dic.First().Key;
            int temp = dic.First().Value;
            dic.Remove(dic.First().Key);

            if (0 != dic.Count())
                if (temp == dic.First().Value)
                    result = -1;

            return result;
        }
        public int Solution14_1(int[] array)
        {
            int answer = 0;
            int iMax = 0;
            int iCount = 0;

            foreach (int val in array.Distinct())
            {
                iCount = array.Count(x => x == val); //val값과 같은 값을 가진수 만큼 iCount에 넣는 것 같음
                if (iCount > iMax)
                {
                    iMax = iCount;
                    answer = val;
                }
                else if (iCount == iMax)
                {
                    answer = -1;
                }
            }

            return answer;
        }   //마음에 들었던 풀이법

        //Lv2_멀리 뛰기_15
        public long Solution15(int n)
        {
            long result = 0;
            long first = 1;
            long second = 0;
            for (int i = 0; i < n; i++)
            {
                result = first + second;

                second = first % 1234567;
                first = result % 1234567;
            }

            return result % 1234567;
        }

        //Lv0_배열 조각하기_16
        public int[] Solution16(int[] arr, int[] query)
        {
            List<int> result = new List<int>();

            result = arr.ToList();

            for (int i = 0; i < query.Length; i++)
                if (i % 2 == 0)
                    result = result.GetRange(0, query[i] + 1);
                else
                    result = result.GetRange(query[i], result.Count - query[i]);

            return result.ToArray();
        }
        public int[] Solution16_1(int[] arr, int[] query)
        {
            int[] answer = new int[] { };

            for (int i = 0; i < query.Length; i++)
                if (i % 2 == 0)
                    arr = arr.Take(query[i] + 1).ToArray(); //IEnumerable로 반환하는듯? 그래서 ToArray 해줘야함
                else
                    arr = arr.Skip(query[i]).ToArray();

            answer = arr;

            return answer;
        }   //마음에 들었던 풀이법

        //Lv2_귤 고르기_17
        public int Solution17(int k, int[] tangerine)
        {
            Dictionary<int, int> dic = new Dictionary<int, int>();
            int result = 0;

            foreach (int i in tangerine)
            {
                if (dic.ContainsKey(i))
                    dic[i]++;
                else
                    dic[i] = 1;
            }

            var list = dic.OrderByDescending(x => x.Value).ToList();

            for (int i = 0; i < list.Count; i++)
            {
                result++;
                k -= list[i].Value;

                if (k <= 0)
                    break;
            }

            return result;
        }   //14번 직접 푼 문제와의 차이는 아마 리스트딕셔너리로 변환해 연산시키는게 더 빠른 것 같음

        //Lv1_명예의 전당 (1)_18
        public int[] Solution18(int k, int[] score)
        {
            List<int> arr = new List<int>();
            int[] result = new int[score.Length];

            for (int i = 0; i < score.Length; i++)
            {
                if (i < k)
                    arr.Add(score[i]);
                else
                {
                    if (arr[0] < score[i])
                        arr[0] = score[i];
                }

                arr.Sort();
                result[i] = arr[0];
            }

            return result;
        }

        //Lv0_OX퀴즈_19
        public string[] Solution19(string[] quiz)
        {
            List<string> result = new List<string>();

            foreach (string quizStr in quiz)
            {
                string[] str = quizStr.Split(" ");

                if (str[1].Equals("+"))
                {
                    if (int.Parse(str[4]) == int.Parse(str[0]) + int.Parse(str[2]))
                        result.Add("O");
                    else
                        result.Add("X");
                }
                else
                {
                    if (int.Parse(str[4]) == int.Parse(str[0]) - int.Parse(str[2]))
                        result.Add("O");
                    else
                        result.Add("X");
                }
            }

            return result.ToArray();
        }
        public string[] Solution19_1(string[] quiz)
        {
            List<string> result = new List<string>();
            DataTable dt = new DataTable();

            foreach (string str in quiz)
            {
                var v = dt.Compute(str, "");

                if ((bool)v == true)
                    result.Add("O");
                else
                    result.Add("X");
            }

            return result.ToArray();
        }   //되긴하는데 프로그래머스에서 System.Data를 지원하지 않는듯? 날먹실패

        //Lv2_연속 부분 수열 합의 개수_20
        public int Solution20(int[] elements)
        {
            List<int> list = new List<int>(elements);
            HashSet<int> hash = new HashSet<int>();

            for (int i = 0; i < elements.Length; i++)
                list.Add(elements[i]);

            for (int i = 0; i < elements.Length; i++)
            {
                int num = 0;

                for (int j = 0; j < elements.Length; j++)
                {
                    num += list[i + j];

                    hash.Add(num);
                }
            }

            return hash.Count;
        }   //Hash는 중복수를 집어넣을 수 없음. Hash 사용법 
        #endregion

        //Lv1_카드 뭉치_21
        public string Solution21(string[] cards1, string[] cards2, string[] goal)
        {
            List<string> listCard1 = cards1.ToList();
            List<string> listCard2 = cards2.ToList();

            for (int i = 0; i < goal.Length; i++)
            {
                if (0 != listCard1.Count && goal[i].Equals(listCard1.First()))
                {
                    listCard1.Remove(goal[i]);
                }
                else if (0 != listCard2.Count && goal[i].Equals(listCard2.First()))
                {
                    listCard2.Remove(goal[i]);
                }
                else
                    return "No";

            }

            return "Yes";
        }

        //Lv2_괄호 회전하기_22
        public int Solution22(string s)
        {
            int result = 0;
            char[] ch = s.ToCharArray();

            for (int i = 0; i < s.Length; i++)
            {
                char temp = ch[ch.Length - 1];

                for (int j = ch.Length - 2; j >= 0; j--)
                {
                    ch[j + 1] = ch[j];
                }

                ch[0] = temp;

                List<int> num = new List<int>();

                for (int j = 0; j < ch.Length; j++)
                {
                    if (num.Count == 0)
                    {
                        if (ch[j] == '[')
                            num.Add(1);
                        else if (ch[j] == '(')
                            num.Add(2);
                        else if (ch[j] == '{')
                            num.Add(3);
                        else
                        {
                            num.Add(-1);
                            break;
                        }
                    }
                    else if (num.Last() == 1)
                    {
                        if (ch[j] == '[')
                            num.Add(1);
                        else if (ch[j] == '(')
                            num.Add(2);
                        else if (ch[j] == '{')
                            num.Add(3);
                        else if (ch[j] == ']')
                            num.RemoveAt(num.Count - 1);
                        else
                            break;
                    }
                    else if (num.Last() == 2)
                    {
                        if (ch[j] == '[')
                            num.Add(1);
                        else if (ch[j] == '(')
                            num.Add(2);
                        else if (ch[j] == '{')
                            num.Add(3);
                        else if (ch[j] == ')')
                            num.RemoveAt(num.Count - 1);
                        else
                            break;
                    }
                    else if (num.Last() == 3)
                    {
                        if (ch[j] == '[')
                            num.Add(1);
                        else if (ch[j] == '(')
                            num.Add(2);
                        else if (ch[j] == '{')
                            num.Add(3);
                        else if (ch[j] == '}')
                            num.RemoveAt(num.Count - 1);
                        else
                            break;
                    }
                }

                if (num.Count == 0)
                    result++;
            }

            return result;
        }

        //Lv2_할인 행사_23
        public int Solution23(string[] want, int[] number, string[] discount)
        {
            int result = 0;

            for (int i = 0; i <= discount.Length - 10; i++)
            {
                int[] index = new int[want.Length];

                for (int j = i; j < 10 + i; j++)
                {
                    for (int k = 0; k < want.Length; k++)
                    {
                        if (discount[j] == want[k])
                        {
                            index[k]++;
                            break;
                        }
                    }
                }
                
                for (int j = 0; j < number.Length; j++)
                {
                    if (index[j] < number[j])
                        break;
                    else if (j == number.Length - 1 && index[j] >= number[j])
                        result++;
                }
            }

            return result;
        }

        //Lv2_n^2 배열 자르기_24
        public int[] Solution24(int n, long left, long right)
        {
            List<int> result = new List<int>();

            for (long i = left; i <= right; i++)
            {
                int num1 = (int)(i % n);
                int num2 = (int)(i / n);
                int temp = (num1 < num2) ? num2 : num1;

                result.Add(temp + 1);
            }

            return result.ToArray();        
        }

        //Lv2_H-Index_25
        public int Solution25(int[] citations)
        {
            Array.Sort(citations);
            Array.Reverse(citations);//9 9 9 9 9 9 9 9

            int result = 0;

            for (int i = citations[0]; i >= 0; i--)
            {
                int temp = 0;
                
                for(int j = 0; j < citations.Length;j++)
                {
                    if (i <= citations[j])
                        temp++;
                    else
                        break;
                }

                if (temp >= i)
                {
                    result = i;

                    break;
                }
            }


            return result;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Test test = new Test(); //ctrl k s = region 생성

            #region 1~10
            #region Lv0_달리기 경주_1
            //string[] players_1 = { "mumu", "soe", "poe", "kai", "mine" };
            //string[] callings_1 = { "kai", "kai", "mine", "mine" };

            //string[] result_1 = test.Solution1(players_1, callings_1);

            //foreach (string r in result_1)
            //    Console.WriteLine(r); 
            #endregion

            #region Lv0_잘라서 배열로 저장하기_2
            //string str_2 = "abc1Addfggg4556b";
            //int length_2 = 6;

            //string[] result_2 = test.Solution2(str_2, length_2);

            //foreach (string str in result_2)
            //    Console.WriteLine(str); 
            #endregion

            #region Lv0_문자 개수 세기_3
            //string str_3 = "Programmers";

            //int[] result_3 = test.Solution3(str_3);

            //Console.WriteLine(string.Join(", ", result_3)); 
            #endregion

            #region Lv1_부족한 금액 계산하기_4
            //int price_4 = 3, money_4 = 20, count_4 = 4;

            //long result_4 = test.Solution4(price_4, money_4, count_4);

            //Console.WriteLine(result_4);
            #endregion

            #region Lv0_배열 만들기 4_5
            //int[] arr_5 = { 4, 4 };

            //int[] result_5 = test.Solution5(arr_5);

            //Console.WriteLine(string.Join(", ", result_5));
            #endregion

            #region Lv0_공 던지기_6
            //int[] numbers_6 = { 1, 2, 3, 4, 5, 6 };
            //int k_6 = 5;

            //int result_6 = test.Solution6(numbers_6, k_6);

            //Console.WriteLine(result_6);
            #endregion

            #region Lv1_푸드 파이트 대회_7
            //int[] food_7 = { 1, 3, 4, 6 };

            //string result_7 = test.Solution7(food_7);

            //Console.WriteLine(result_7);
            #endregion

            #region Lv1_두 개 뽑아서 더하기_8
            //int[] numbers_8 = { 5, 0, 2, 7 };

            //int[] result_8 = test.Solution8(numbers_8);

            //Console.WriteLine(string.Join(", ", result_8));
            #endregion

            #region Lv2_점프와 순간 이동_9
            //int n_9 = 5000;

            //int result_9 = test.Solution9(n_9);

            //Console.WriteLine(result_9);
            #endregion

            #region Lv2_예상 대진표_10
            //int n_10 = 8, a_10 = 4, b_10 = 7;

            //int result_10 = test.Solution10(n_10, a_10, b_10);

            //Console.WriteLine(result_10);
            #endregion
            #endregion

            #region 11~20
            #region Lv1_콜라 문제_11
            //int a_11 = 3, b_11 = 1, n_11 = 20;

            //Console.WriteLine(test.Solution11(a_11, b_11, n_11));
            #endregion

            #region Lv2_N개의 최소공배수_12
            //int[] arr_12 = { 2, 6, 8, 14 };
            //Console.WriteLine(test.Solution12(arr_12));
            #endregion

            #region Lv0_문자열 출력하기_13
            //test.Solution13();
            #endregion

            #region Lv0_최빈값 구하기_14
            //int[] arr_14 = { 1,1,1,2,2,3,3 };
            //Console.WriteLine(test.Solution14(arr_14));
            #endregion

            #region Lv2_멀리 뛰기_15
            //int n_15 = 7;
            //Console.WriteLine(test.Solution15(n_15));
            #endregion

            #region Lv0_배열 조각하기_16
            //int[] arr_16 = { 0, 1, 2, 3, 4, 5 };
            //int[] query_16 = { 4, 1, 2 };

            //Console.Write(String.Join(", ", test.Solution16(arr_16, query_16)));
            #endregion

            #region Lv2_귤 고르기_17
            //int k_17 = 4;
            //int[] tangerine_17 = { 1, 3, 2, 5, 4, 5, 2, 3 };
            //Console.WriteLine(test.Solution17(k_17, tangerine_17));
            #endregion

            #region Lv1_명예의 전당 (1)_18
            //int k_18 = 4;
            //int[] score_18 = { 0, 300, 40, 300, 20, 70, 150, 50, 500, 1000 };
            //Console.WriteLine(String.Join(", ", test.Solution18(k_18,score_18)));
            #endregion

            #region Lv0_OX퀴즈_19
            //string[] quiz = { "3 - 4 = -3", "5 + 6 = 11" };
            //Console.WriteLine(string.Join(", ", test.Solution19(quiz)));
            #endregion

            #region Lv2_연속 부분 수열 합의 개수_20
            //int[] elements_20 = { 7, 9, 1, 1, 4 };
            //Console.WriteLine(test.Solution20(elements_20));
            #endregion
            #endregion

            #region Lv1_카드 뭉치_21
            //string[] cards1_21 = { "i", "drink", "water" };
            //string[] cards2_21 = { "want", "to" };
            //string[] goal_21 = { "i", "want", "to", "drink", "water" };
            //Console.WriteLine(test.Solution21(cards1_21, cards2_21, goal_21));
            #endregion

            #region Lv2_괄호 회전하기_22
            //string s_22 = "[](){}";
            //Console.WriteLine(test.Solution22(s_22));
            #endregion

            #region Lv2_할인 행사_23
            //string[] want_23 = { "banana", "apple", "rice", "pork", "pot" };
            //int[] number_23 = { 3, 2, 2, 2, 1 };
            //string[] discount_23 = { "chicken", "apple", "apple", "banana", "rice", "apple", "pork", "banana", "pork", "rice", "pot", "banana", "apple", "banana" };
            //Console.WriteLine(test.Solution23(want_23, number_23, discount_23));
            #endregion

            #region Lv2_n^2 배열 자르기_24
            //int n_24 = 3;
            //long left_24 = 2;
            //long right_24 = 5;
            //Console.WriteLine(string.Join(", ", test.Solution24(n_24, left_24, right_24)));
            #endregion

            #region Lv2_H-Index_25
            //int[] citations_25 = { 9,9,9,9,9,9,9,9 };
            //Console.WriteLine(test.Solution25(citations_25));
            #endregion
        }
    }
}
