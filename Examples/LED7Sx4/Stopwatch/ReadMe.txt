Description
  This is an example to show how to make a simple Stopwatch with a 7-Segment Display and 6502
  The example implement Stopwatch code flow without RTC.
  
Button Action
  Reset button to clear the timer
  Start button to start/stop the timer
  
Memory Map
  RAM           $0000 - $1FFF
  XIO_LED&Sx4   $C000 - $DFFF
  ROM           $E000 - $FFFF