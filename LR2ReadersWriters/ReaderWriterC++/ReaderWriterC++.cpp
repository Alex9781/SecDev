#define _CRT_SECURE_NO_WARNINGS

#include <iostream>
#include <chrono>
#include <ctime>

int main()
{
	while (true)
	{
		std::string input;
		std::string fileName;
		std::cout << "[r]/[w]: ";
		std::cin >> input >> fileName;

		if (input == "r")
		{
			FILE* fp;
			fopen_s(&fp, fileName.c_str(), "r+");
			char read[1024];
			if (fp)
			{
				fread_s(read, 1024, 1, 1024, fp);
				std::cout << read;
				fclose(fp);
			}
		}
		if (input == "w")
		{
			FILE* fp;
			fopen_s(&fp, fileName.c_str(), "r+");
			if (fp)
			{
				auto toWrite = std::chrono::system_clock::now();
				std::time_t toWriteTime = std::chrono::system_clock::to_time_t(toWrite);
				auto toWriteChar = std::ctime(&toWriteTime);
				char newString[50];
				strcat(newString, toWriteChar);
				strcat(newString, " ");
				strcat(newString, toWriteChar);

				std::cout << newString;

				fwrite(newString, strlen(newString), 1, fp);
				fflush(fp);
				fclose(fp);
			}
		}
		if (input == "e")
		{
			return 0;
		}
	}
}
