<?xml version="1.0" encoding="utf-8"?>
<profile:profile name="Bubble Bobble"
    xsi:schemaLocation="http://romhackers.net/porno-graphic/profile profile.xsd"
    xmlns:profile="http://romhackers.net/porno-graphic/profile"
    xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance"
>
  <layouts>
    <layout name="Bubble Bobble Character Layout">
      <plane multiplier="4">
        <offset bits="0" />
        <offset bits="1" />
	    <offset bits="0" fracnum="1" fracden="2" />
        <offset bits="1" fracnum="1" fracden="2" />
      </plane>
      <x multiplier="1">
        <offset bits="3" />
        <offset bits="2" />
        <offset bits="1" />
        <offset bits="0" />
        <offset bits="11" />
        <offset bits="10" />
        <offset bits="9" />
        <offset bits="8" />
      </x>
      <y multiplier="16">
        <offset bits="0" />
        <offset bits="1" />
        <offset bits="2" />
        <offset bits="3" />
        <offset bits="4" />
        <offset bits="5" />
        <offset bits="6" />
        <offset bits="7" />
      </y>
      <stride>128</stride>
    </layout>
  </layouts>
	<regions>
		<region name="Bubble Bobble" length="80000" invert="true">
			<file name="12">
				<load offset="00000" size="8000"/>
			</file>
			<file name="13">
				<load offset="08000" size="8000"/>
			</file>
			<file name="14">
				<load offset="10000" size="8000"/>
			</file>
			<file name="15">
				<load offset="18000" size="8000"/>
			</file>
			<file name="16">
				<load offset="20000" size="8000"/>
			</file>
			<file name="17">
				<load offset="28000" size="8000"/>
			</file>
			<fill offset="30000" size="10000" value="00"/>
			<file name="30">
				<load offset="40000" size="8000"/>
			</file>
			<file name="31">
				<load offset="48000" size="8000"/>
			</file>
			<file name="32">
				<load offset="50000" size="8000"/>
			</file>
			<file name="33">
				<load offset="58000" size="8000"/>
			</file>
			<file name="34">
				<load offset="60000" size="8000"/>
			</file>
			<file name="35">
				<load offset="68000" size="8000"/>
			</file>
		</region>
	</regions>
</profile:profile>
