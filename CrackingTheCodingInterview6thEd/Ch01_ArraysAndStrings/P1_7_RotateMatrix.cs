using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrackingTheCodingInterview6thEd.Ch01_ArraysAndStrings
{
    public class P1_7_RotateMatrix
    {
        public static void Rotate90DegreesInPlace(int[][] matrix)
        {
            //if it's not a square matrix return
            if (matrix.Length == 0 || (matrix.Length != matrix[0].Length))
                return;

            //inplace istenmeseydi aşağıdaki gibi olurdu, ama inplace isteniyor..
            //4x4 matris için:
            //0. satır => 3. sütun
            //1. satır => 2. sütun
            //2. satır => 1. sütun
            //3. satır => 0. sütun

            //yani r. satırı => (length-1-r). sütuna taşınacaktı (inplace istenmeseydi)
            //yani m[r,c] => m[r, (length-1-r)]

            //inplace istendiği için dıştan içe dairesel şekilde katmanları rotate et
            //örneğin 9x9 matris için, önce dış sonra iç kare katmanın kenarları rotate edilecek
            //00 01 02 03 04 05 06 07 08       80 70 60 50 40 30 20 10 00
            //10 11 12 13 14 15 16 17 18       81 71 61 51 41 31 21 11 01
            //20 21 22 23 24 25 26 27 28       82 72 62 52 42 32 22 12 02
            //30 31 32 33 34 35 36 37 38       83 73 63 53 43 33 23 13 03
            //40 41 42 43 44 45 46 47 48   =>  84 74 64 54 44 34 24 14 04
            //50 51 52 53 54 55 56 57 58       85 75 65 55 45 35 25 15 05
            //60 61 62 63 64 65 66 67 68       86 76 66 56 46 36 26 16 06
            //70 71 72 73 74 75 76 77 78       87 77 67 57 47 37 27 17 07
            //80 81 82 83 84 85 86 87 88       88 78 68 58 48 38 28 18 08
            //
            //9x9 matris en dış katman (layer:0) için her kenardaki 3.elemanların rotasyonu: 
            //tek temp kullanmak için bunları ters sırada çalıştır (önce temp=02)
            //02 => 28
            //28 => 86
            //86 => 60
            //60 => 02

            //9x9 matris 1. katman (layer:1) için her kenardaki 3.elemanların rotasyonu: 
            //tek temp kullanmak için bunları ters sırada çalıştır (önce temp=13)
            //13 => 37 (1: layer, 3: layer + eleman indexi, 7: matrix length - 1 - layer)
            //37 => 75 (5: matrix length - 1 - layer - eleman indexi)
            //75 => 51 (1: layer)
            //51 => 13 3: layer + eleman indexi)

            //9x9 matris 2. katman (layer:2) için her kenardaki 3.elemanların rotasyonu: 
            //tek temp kullanmak için bunları ters sırada çalıştır (önce temp=24)
            //24 => 46 (2: layer, 4: layer + eleman indexi, 6: matrix length - 1 - layer)
            //46 => 64 (4: matrix length - 1 - layer - eleman indexi)
            //64 => 42 (2: layer)
            //42 => 24 (4: layer + eleman indexi)

            //9x9 matris 3. katman (layer:3) için her kenardaki 3.elemanların rotasyonu: 
            //tek temp kullanmak için bunları ters sırada çalıştır (önce temp=35)
            //35 => 55 (3: layer, 5: layer + eleman indexi, 5: matrix length - 1 - layer)
            //55 => 53 (3: matrix length - 1 - layer - eleman indexi)
            //53 => 33 (3: layer)
            //33 => 35 (5: layer + eleman indexi)

            //yani: 
            //her l:0..n için:
            //  her i:l..l-1 için: (i: yukarıdaki layer + eleman indexi)
            //      ml = matrix length
            //      temp   = m[l,i]                 //ml:9, l:1, i:3 örneği için temp=13
            //      m[l,i] = m[ml-1-i,l]            //ml:9, l:1, i:3 örneği için 51 => 13
            //      m[ml-1-i,l] = m[ml-1-l,ml-1-i]  //ml:9, l:1, i:3 örneği için 75 => 51
            //      m[ml-1-l,ml-1-i] = m[i,ml-1-l]  //ml:9, l:1, i:3 örneği için 37 => 75
            //      m[i,ml-1-l] = temp              //ml:9, l:1, i:3 örneği için 13 => 37

            //9x9 matris 1. katman (layer:1) için her kenardaki 3.elemanların rotasyonu: 
            //tek temp kullanmak için bunları ters sırada çalıştır (önce temp=13)
            //13 => 37 (1: layer, 3: layer + eleman indexi, 7: matrix length - 1 - layer)
            //37 => 75 (5: matrix length - 1 - layer - eleman indexi)
            //75 => 51 (1: layer)
            //51 => 13 3: layer + eleman indexi)
            Debug.WriteLine("start");
            var ml = matrix.Length;
            for (int layer = 0; layer < ml / 2; layer++)
            {
                Debug.WriteLine("layer:" + layer);

                var l = layer;
                var layerLength = ml - (2 * layer);
                for (int i = layer; i < layer + layerLength - 1; i++)
                {
                    //[layer][layer] iç matrisin orijin (0,0) noktası
                    var temp = matrix[l][i];                //ml:9, l:1, i:3 örneği için temp=13

                    Debug.WriteLine(matrix[ml - 1 - i][l] + " to " + matrix[l][i]);
                    matrix[l][i] = matrix[ml - 1 - i][l];            //ml:9, l:1, i:3 örneği için 51 => 13

                    Debug.WriteLine(matrix[ml - 1 - l][ml - 1 - i] + " to " + matrix[ml - 1 - i][l]);
                    matrix[ml - 1 - i][l] = matrix[ml - 1 - l][ml - 1 - i];  //ml:9, l:1, i:3 örneği için 75 => 51

                    Debug.WriteLine(matrix[i][ml - 1 - l] + " to " + matrix[ml - 1 - l][ml - 1 - i]);
                    matrix[ml - 1 - l][ml - 1 - i] = matrix[i][ml - 1 - l];  //ml:9, l:1, i:3 örneği için 37 => 75

                    Debug.WriteLine(temp + " to " + matrix[i][ml - 1 - l]);
                    matrix[i][ml - 1 - l] = temp;              //ml:9, l:1, i:3 örneği için 13 => 37

                    Debug.WriteLine("");

                }
            }
        }
    }
}
