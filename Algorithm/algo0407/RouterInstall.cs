using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace algo0407
{
    public partial class Program
    {
        public static void RouterInstall()
        {
            string[] inputData = Console.ReadLine().Split();
            long houseCount = long.Parse(inputData[0]);
            long routerCount = long.Parse(inputData[1]);

            long[] housePoints = new long[houseCount];
            for (int i = 0; i < houseCount; i++) 
            {
                housePoints[i] = long.Parse(Console.ReadLine());
            }
            Array.Sort(housePoints);

            //범위 : start, end 설정을 어떻게 할까?
            //와꾸 : (start는 1, end는 맨 뒤에 points 값)
            long start = 1;
            long end = housePoints[houseCount - 1];

            long result = 1;
            while(start <= end)
            {
                //가장 인접한 거리 : mid
                //Logic
                //sum : 설치 된 라우터 개수
                long installCount = 1;
                long installPos = 0; //설치된 집 주소

                long mid = start + (end - start) / 2;

                for (int i = 1; i < houseCount; i++)
                {
                    if (housePoints[i] - housePoints[installPos] >= mid) //최솟값 보다 크거나 같에 설치
                    {
                        installCount++;
                        installPos = i;
                    }
                }
                //설치 개수가 같으면? -> 거리를 늘려!
                if(installCount >= routerCount) //설치 개수가 많아? -> 거리를 늘려
                {
                    result = mid;
                    start = mid + 1;
                }
                else //설치 개수가 적다? => 거리를 좁혀!
                {
                    end = mid - 1;
                }

            }

            //출력 : 최대 거리
            Console.WriteLine(result.ToString());
        }
    }
}
