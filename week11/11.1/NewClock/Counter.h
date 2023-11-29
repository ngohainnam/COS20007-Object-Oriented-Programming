#include <iostream>
#include <thread>
#include <chrono>

int main() {
    Clock clock;  // Create a Clock object
    while (true) {
        // Wait for 100 milliseconds
        std::this_thread::sleep_for(std::chrono::milliseconds(100));
        // Clear the console (Note: "clear" for UNIX/Linux)
        system("CLS");
        // Output the current time string to the console
        std::cout << clock.GetTimeString() << std::endl;
        // Process the next tick (increment counters)
        clock.Ticks();
    }
    return 0;
}
