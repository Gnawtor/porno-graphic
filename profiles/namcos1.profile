<?xml version="1.0" encoding="utf-8"?>
<profile:profile name="Namco System 1"
    xsi:schemaLocation="http://romhackers.net/porno-graphic/profile profile.xsd"
    xmlns:profile="http://romhackers.net/porno-graphic/profile"
    xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance"
>
  <layouts>
	<layout name="Character (namco_c123tmap)">
		<plane>
			<offset bits="0" />
			<offset bits="1" />
			<offset bits="2" />
			<offset bits="3" />
			<offset bits="4" />
			<offset bits="5" />
			<offset bits="6" />
			<offset bits="7" />
		</plane>
		<x multiplier="8">
			<offset bits="0" />
			<offset bits="1" />
			<offset bits="2" />
			<offset bits="3" />
			<offset bits="4" />
			<offset bits="5" />
			<offset bits="6" />
			<offset bits="7" />
		</x>
		<y multiplier="64" >
			<offset bits="0" />
			<offset bits="1" />
			<offset bits="2" />
			<offset bits="3" />
			<offset bits="4" />
			<offset bits="5" />
			<offset bits="6" />
			<offset bits="7" />
		</y>
		<stride>512</stride>
	</layout>
    <layout name="Sprite">
      <plane>
        <offset bits="0" />
        <offset bits="1" />
        <offset bits="2" />
        <offset bits="3" />
      </plane>
      <x multiplier="4">
        <offset bits="0" />
        <offset bits="1" />
        <offset bits="2" />
        <offset bits="3" />
        <offset bits="4" />
        <offset bits="5" />
        <offset bits="6" />
        <offset bits="7" />
        <offset bits="8" />
        <offset bits="9" />
        <offset bits="10" />
        <offset bits="11" />
        <offset bits="12" />
        <offset bits="13" />
        <offset bits="14" />
        <offset bits="15" />
        <offset bits="256" />
        <offset bits="257" />
        <offset bits="258" />
        <offset bits="259" />
        <offset bits="260" />
        <offset bits="261" />
        <offset bits="262" />
        <offset bits="263" />
        <offset bits="264" />
        <offset bits="265" />
        <offset bits="266" />
        <offset bits="267" />
        <offset bits="268" />
        <offset bits="269" />
        <offset bits="270" />
        <offset bits="271" />
      </x>
      <y multiplier="64">
        <offset bits="0" />
        <offset bits="1" />
        <offset bits="2" />
        <offset bits="3" />
        <offset bits="4" />
        <offset bits="5" />
        <offset bits="6" />
        <offset bits="7" />
        <offset bits="8" />
        <offset bits="9" />
        <offset bits="10" />
        <offset bits="11" />
        <offset bits="12" />
        <offset bits="13" />
        <offset bits="14" />
        <offset bits="15" />
        <offset bits="32" />
        <offset bits="33" />
        <offset bits="34" />
        <offset bits="35" />
        <offset bits="36" />
        <offset bits="37" />
        <offset bits="38" />
        <offset bits="39" />
        <offset bits="40" />
        <offset bits="41" />
        <offset bits="42" />
        <offset bits="43" />
        <offset bits="44" />
        <offset bits="45" />
        <offset bits="46" />
        <offset bits="47" />
      </y>
      <stride>4096</stride>
    </layout>
  </layouts>

  <regions>
     <region name="Pac-Mania (Character)" length="80000">
      <file name="pn_chr-0.bin">
        <load offset="000000" size="20000" />
      </file>
      <file name="pn_chr-1.bin">
        <load offset="20000" size="20000" />
      </file>
	  <file name="pn_chr-2.bin">
        <load offset="40000" size="20000" />
      </file>
	  <file name="pn_chr-3.bin">
        <load offset="60000" size="20000" />
      </file>
    </region>
    <region name="Pac-Mania (Sprite)" length="40000">
      <file name="pn_obj-0">
        <load offset="000000" size="20000" />
      </file>
      <file name="pnx_obj1">
        <load offset="20000" size="20000" />
      </file>
    </region>
  </regions>
</profile:profile>
