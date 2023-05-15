//#define _CRT_SECURE_NO_WARNINGS
//
//#include <iostream>
//#include <chrono>
//#include <ctime>
//
//int main()
//{
//	while (true)
//	{
//		std::string input;
//		std::string fileName;
//		std::cout << "[r]/[w]: ";
//		std::cin >> input >> fileName;
//
//		if (input == "r")
//		{
//			FILE* fp;
//			fopen_s(&fp, fileName.c_str(), "r");
//			char read[1024];
//			if (fp)
//			{
//				fread_s(read, 1024, 1, 1024, fp);
//				std::cout << read;
//				fclose(fp);
//			}
//		}
//		if (input == "w")
//		{
//			FILE* fp;
//			fopen_s(&fp, fileName.c_str(), "w+");
//			if (fp)
//			{
//				auto toWrite = std::chrono::system_clock::now();
//				std::time_t toWriteTime = std::chrono::system_clock::to_time_t(toWrite);
//				auto toWriteChar = std::ctime(&toWriteTime);
//				/*char newString[50];
//				strcat(newString, toWriteChar);
//				strcat(newString, " ");
//				strcat(newString, toWriteChar);*/
//
//				/*std::cout << newString;*/
//
//				/*fwrite(newString, strlen(newString), 1, fp);*/
//
//				std::cout << toWriteChar;
//				fwrite(toWriteChar, strlen(toWriteChar), 1, fp);
//
//				fflush(fp);
//				fclose(fp);
//			}
//		}
//		if (input == "e")
//		{
//			return 0;
//		}
//	}
//}


#include<stdio.h>  
#include<time.h>
#include<string.h>

int main() 
{
    FILE* file;
    const size_t len = 1024;

    if (fopen_s(&file, "qwe.kek", "r+")) 
    {
        printf_s("Ошибка в открытие файла!");
        getchar();
        return 0;
    }

    char buffer[len] = { 0 };
    fread_s(buffer, len, sizeof(char), len, file);
    printf_s("%s\n", buffer);

    time_t rawtime;
    struct tm info;
    time(&rawtime);
    localtime_s(&info, &rawtime);

    memset(buffer, '\0', len);
    strftime(buffer, len, "%Y-%m-%d %H:%M:%S ", &info);
    //strcat_s(buffer, "Korotaev Kirill 201-331\n");

    fseek(file, 0, SEEK_SET);
    fwrite(buffer, sizeof(char), len, file);

    fclose(file);

    getchar();

    return 0;


}