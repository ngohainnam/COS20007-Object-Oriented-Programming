#include <iostream>
#include <thread>
#include <chrono>
#include "Clock.cpp"

int main() {
    Clock clock;  
    while (true) 
    {
        std::this_thread::sleep_for(std::chrono::milliseconds(200));
        // Clear the console
        system("CLS");
        // Output the current time string to the console
        std::cout << clock.GetTimeString() << std::endl;
        clock.Ticks();
    }
    return 0;
}
