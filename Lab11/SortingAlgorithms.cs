using System;

public static class SortingAlgorithms
{
    public static void HeapSort(int[] array)
    {
        int n = array.Length;

        for (int i = n / 2 - 1; i >= 0; i--)
            Heapify(array, n, i);

        for (int i = n - 1; i > 0; i--)
        {
            int temp = array[0];
            array[0] = array[i];
            array[i] = temp;

            Heapify(array, i, 0);
        }
    }

    private static void Heapify(int[] array, int n, int i)
    {
        int largest = i;
        int left = 2 * i + 1;
        int right = 2 * i + 2;

        if (left < n && array[left] > array[largest])
            largest = left;

        if (right < n && array[right] > array[largest])
            largest = right;

        if (largest != i)
        {
            int swap = array[i];
            array[i] = array[largest];
            array[largest] = swap;

            Heapify(array, n, largest);
        }
    }

    public static void QuickSort(int[] array)
    {
        QuickSort(array, 0, array.Length - 1);
    }

    private static void QuickSort(int[] array, int low, int high)
    {
        if (low < high)
        {
            int pivot = Partition(array, low, high);
            QuickSort(array, low, pivot - 1);
            QuickSort(array, pivot + 1, high);
        }
    }

    private static int Partition(int[] array, int low, int high)
    {
        int pivot = array[high];
        int i = low - 1;
        for (int j = low; j < high; j++)
        {
            if (array[j] < pivot)
            {
                i++;
                Swap(ref array[i], ref array[j]);
            }
        }
        Swap(ref array[i + 1], ref array[high]);
        return i + 1;
    }

    private static void Swap(ref int a, ref int b)
    {
        int temp = a;
        a = b;
        b = temp;
    }

    public static void SmoothSort(int[] array)
    {
        int q, r, p, b, c, r1, b1, c1;

        bool IsAscending(int A, int B)
        {
            return A < B;
        }

        void UP(ref int IA, ref int IB, ref int temp)
        {
            temp = IA;
            IA += IB + 1;
            IB = temp;
        }

        void DOWN(ref int IA, ref int IB, ref int temp)
        {
            temp = IB;
            IB = IA - IB - 1;
            IA = temp;
        }

        void Sift(ref int[] A)
        {
            int r0, r2, temp = 0;
            int t;
            r0 = r1;
            t = A[r0];

            while (b1 >= 3)
            {
                r2 = r1 - b1 + c1;

                if (!IsAscending(A[r1 - 1], A[r2]))
                {
                    r2 = r1 - 1;
                    DOWN(ref b1, ref c1, ref temp);
                }

                if (IsAscending(A[r2], t))
                {
                    b1 = 1;
                }
                else
                {
                    A[r1] = A[r2];
                    r1 = r2;
                    DOWN(ref b1, ref c1, ref temp);
                }
            }

            if (Convert.ToBoolean(r1 - r0))
                A[r1] = t;
        }

        void Trinkle(ref int[] A)
        {
            int p1, r2, r3, r0, temp = 0;
            int t;
            p1 = p;
            b1 = b;
            c1 = c;
            r0 = r1;
            t = A[r0];

            while (p1 > 0)
            {
                while ((p1 & 1) == 0)
                {
                    p1 >>= 1;
                    UP(ref b1, ref c1, ref temp);
                }

                r3 = r1 - b1;

                if ((p1 == 1) || IsAscending(A[r3], t))
                {
                    p1 = 0;
                }
                else
                {
                    --p1;

                    if (b1 == 1)
                    {
                        A[r1] = A[r3];
                        r1 = r3;
                    }
                    else
                    {
                        if (b1 >= 3)
                        {
                            r2 = r1 - b1 + c1;

                            if (!IsAscending(A[r1 - 1], A[r2]))
                            {
                                r2 = r1 - 1;
                                DOWN(ref b1, ref c1, ref temp);
                                p1 <<= 1;
                            }
                            if (IsAscending(A[r2], A[r3]))
                            {
                                A[r1] = A[r3]; r1 = r3;
                            }
                            else
                            {
                                A[r1] = A[r2];
                                r1 = r2;
                                DOWN(ref b1, ref c1, ref temp);
                                p1 = 0;
                            }
                        }
                    }
                }
            }

            if (Convert.ToBoolean(r0 - r1))
                A[r1] = t;

            Sift(ref A);
        }

        void SemiTrinkle(ref int[] A)
        {
            int T;
            r1 = r - c;

            if (!IsAscending(A[r1], A[r]))
            {
                T = A[r];
                A[r] = A[r1];
                A[r1] = T;
                Trinkle(ref A);
            }
        }

        int temp = 0;
        q = 1;
        r = 0;
        p = 1;
        b = 1;
        c = 1;

        while (q < array.Length)
        {
            r1 = r;
            if ((p & 7) == 3)
            {
                b1 = b;
                c1 = c;
                Sift(ref array);
                p = (p + 1) >> 2;
                UP(ref b, ref c, ref temp);
                UP(ref b, ref c, ref temp);
            }
            else if ((p & 3) == 1)
            {
                if (q + c < array.Length)
                {
                    b1 = b;
                    c1 = c;
                    Sift(ref array);
                }
                else
                {
                    Trinkle(ref array);
                }

                DOWN(ref b, ref c, ref temp);
                p <<= 1;

                while (b > 1)
                {
                    DOWN(ref b, ref c, ref temp);
                    p <<= 1;
                }

                ++p;
            }

            ++q;
            ++r;
        }

        r1 = r;
        Trinkle(ref array);

        while (q > 1)
        {
            --q;

            if (b == 1)
            {
                --r;
                --p;

                while ((p & 1) == 0)
                {
                    p >>= 1;
                    UP(ref b, ref c, ref temp);
                }
            }
            else
            {
                if (b >= 3)
                {
                    --p;
                    r = r - b + c;
                    if (p > 0)
                        SemiTrinkle(ref array);

                    DOWN(ref b, ref c, ref temp);
                    p = (p << 1) + 1;
                    r = r + c;
                    SemiTrinkle(ref array);
                    DOWN(ref b, ref c, ref temp);
                    p = (p << 1) + 1;
                }
            }
        }
    }
}
