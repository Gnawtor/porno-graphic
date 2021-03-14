<?xml version="1.0" encoding="utf-8"?>
<profile:profile name="Renegade/Nekketsu Kouha Kunio Kun"
    xsi:schemaLocation="http://romhackers.net/porno-graphic/profile profile.xsd"
    xmlns:profile="http://romhackers.net/porno-graphic/profile"
    xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance"
>
  <layouts>
    <layout name="Renegade Char">
      <plane multiplier="1">
        <offset bits="2" />
        <offset bits="4" />
        <offset bits="6" />
      </plane>
      <x multiplier="1">
        <offset bits="1" />
        <offset bits="0" />
        <offset bits="65" />
        <offset bits="64" />
        <offset bits="129" />
        <offset bits="128" />
        <offset bits="193" />
        <offset bits="192" />
      </x>
      <y multiplier="8">
        <offset bits="0" />
        <offset bits="1" />
        <offset bits="2" />
        <offset bits="3" />
        <offset bits="4" />
        <offset bits="5" />
        <offset bits="6" />
        <offset bits="7" />
      </y>
      <stride>256</stride>
    </layout>
	<layout name="Renegade Tile Layout 1">
      <plane multiplier="1">
        <offset bits="4" />
        <offset bits="262144" />
        <offset bits="262148" />
      </plane>
      <x multiplier="1">
        <offset bits="3" />
        <offset bits="2" />
        <offset bits="1" />
        <offset bits="0" />
        <offset bits="131" />
        <offset bits="130" />
        <offset bits="129" />
        <offset bits="129" />
		<offset bits="259" />
		<offset bits="258" />
		<offset bits="257" />
		<offset bits="256" />
		<offset bits="387" />
		<offset bits="386" />
		<offset bits="385" />
		<offset bits="384" />
      </x>
      <y multiplier="8">
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
      </y>
      <stride>512</stride>
    </layout>
	<layout name="Renegade Tile Layout 2">
      <plane multiplier="1">
        <offset bits="0" />
        <offset bits="393216" />
        <offset bits="393220" />
      </plane>
      <x multiplier="1">
        <offset bits="3" />
        <offset bits="2" />
        <offset bits="1" />
        <offset bits="0" />
        <offset bits="131" />
        <offset bits="130" />
        <offset bits="129" />
        <offset bits="129" />
		<offset bits="259" />
		<offset bits="258" />
		<offset bits="257" />
		<offset bits="256" />
		<offset bits="387" />
		<offset bits="386" />
		<offset bits="385" />
		<offset bits="384" />
      </x>
      <y multiplier="8">
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
      </y>
      <stride>512</stride>
    </layout>
		<layout name="Renegade Tile Layout 3">
      <plane multiplier="1">
        <offset bits="131076" />
        <offset bits="524288" />
        <offset bits="524292" />
      </plane>
      <x multiplier="1">
        <offset bits="3" />
        <offset bits="2" />
        <offset bits="1" />
        <offset bits="0" />
        <offset bits="131" />
        <offset bits="130" />
        <offset bits="129" />
        <offset bits="129" />
		<offset bits="259" />
		<offset bits="258" />
		<offset bits="257" />
		<offset bits="256" />
		<offset bits="387" />
		<offset bits="386" />
		<offset bits="385" />
		<offset bits="384" />
      </x>
      <y multiplier="8">
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
      </y>
      <stride>512</stride>
    </layout>
	<layout name="Renegade Tile Layout 4">
      <plane multiplier="1">
        <offset bits="131072" />
        <offset bits="655360" />
        <offset bits="655364" />
      </plane>
      <x multiplier="1">
        <offset bits="3" />
        <offset bits="2" />
        <offset bits="1" />
        <offset bits="0" />
        <offset bits="131" />
        <offset bits="130" />
        <offset bits="129" />
        <offset bits="129" />
		<offset bits="259" />
		<offset bits="258" />
		<offset bits="257" />
		<offset bits="256" />
		<offset bits="387" />
		<offset bits="386" />
		<offset bits="385" />
		<offset bits="384" />
      </x>
      <y multiplier="8">
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
      </y>
      <stride>512</stride>
    </layout>
  </layouts>
	<regions>
		<region name="Renegade chars" length="08000">
			<file name="nc-5">
				<load offset="00000" size="08000" />
			</file>
		</region>
		<region name="Renegade tiles" length="30000">
			<file name="n1-5">
				<load offset="00000" size="08000" />
			</file>
			<file name="n6-5">
				<load offset="08000" size="08000" />
			</file>
			<file name="n7-5">
				<load offset="10000" size="08000" />
			</file>
			<file name="n2-5">
				<load offset="18000" size="08000" />
			</file>
			<file name="n8-5">
				<load offset="20000" size="08000" />
			</file>
			<file name="n9-5">
				<load offset="28000" size="08000" />
			</file>
		</region>
		<region name="Renegade sprites" length="60000">
			<file name="nh-5">
				<load offset="00000" size="08000" />
			</file>
			<file name="nd-5">
				<load offset="08000" size="08000" />
			</file>
			<file name="nj-5">
				<load offset="10000" size="08000" />
			</file>
			<file name="nn-5">
				<load offset="18000" size="08000" />
			</file>
			<file name="ne-5">
				<load offset="20000" size="08000" />
			</file>
			<file name="nk-5">
				<load offset="28000" size="08000" />
			</file>
			<file name="ni-5">
				<load offset="30000" size="08000" />
			</file>
			<file name="nf-5">
				<load offset="38000" size="08000" />
			</file>
			<file name="nl-5">
				<load offset="40000" size="08000" />
			</file>
			<file name="no-5">
				<load offset="48000" size="08000" />
			</file>
			<file name="ng-5">
				<load offset="50000" size="08000" />
			</file>
			<file name="nm-5">
				<load offset="58000" size="08000" />
			</file>
		</region>
				<region name="Nekketsu Kouha Kunio Kun chars" length="08000">
			<file name="ta18-25">
				<load offset="00000" size="08000" />
			</file>
		</region>
		<region name="Nekketsu Kouha Kunio Kun tiles" length="30000">
			<file name="ta18-01">
				<load offset="00000" size="08000" />
			</file>
			<file name="ta18-06">
				<load offset="08000" size="08000" />
			</file>
			<file name="n7-5">
				<load offset="10000" size="08000" />
			</file>
			<file name="ta18-02">
				<load offset="18000" size="08000" />
			</file>
			<file name="ta18-04">
				<load offset="20000" size="08000" />
			</file>
			<file name="ta18-03">
				<load offset="28000" size="08000" />
			</file>
		</region>
		<region name="Nekketsu Kouha Kunio Kun sprites" length="60000">
			<file name="ta18-20">
				<load offset="00000" size="08000" />
			</file>
			<file name="ta18-24">
				<load offset="08000" size="08000" />
			</file>
			<file name="ta18-18">
				<load offset="10000" size="08000" />
			</file>
			<file name="ta18-14">
				<load offset="18000" size="08000" />
			</file>
			<file name="ta18-23">
				<load offset="20000" size="08000" />
			</file>
			<file name="ta18-17">
				<load offset="28000" size="08000" />
			</file>
			<file name="ta18-19">
				<load offset="30000" size="08000" />
			</file>
			<file name="ta18-22">
				<load offset="38000" size="08000" />
			</file>
			<file name="ta18-16">
				<load offset="40000" size="08000" />
			</file>
			<file name="ta18-13">
				<load offset="48000" size="08000" />
			</file>
			<file name="ta18-21">
				<load offset="50000" size="08000" />
			</file>
			<file name="ta18-15">
				<load offset="58000" size="08000" />
			</file>
		</region>
	</regions>
</profile:profile>
