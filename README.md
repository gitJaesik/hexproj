# hexproj
noh's project

This Project is for writing some specific hex files.

I made this windows program for someone who have to use hex files but don't know how to use it.
------------------------------------------------------------------------------------------
The Line looks like :
":1035400004021B0414000000000000555555557777"

And it'd be clasified like this:
: 10 3540 00 04021B04140000000000005555555577 77

first ":" is nothing special but means that it's start on the line.

second "10" is that 0x10. It means that the number of hex data is 0x10. (In the decimal, it's 16)

thrid "3540" present address number.

fourth "00" means type of data. "00" means data, "01" means End Of File, and other value mean address. 
(you can see it http://en.wikipedia.org/wiki/Intel_HEX))

fifth "04021B04140000000000005555555577" is data.

sixth "77" means checksum of "10 3540 00 04021B04140000000000005555555577".
Add all hexdecimal value and then adjust 2'compliments.

------------------------------------------------------------------------------------------
