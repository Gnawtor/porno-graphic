<?xml version="1.0" encoding="utf-8"?>
<profile:profile name="Funworld"
    xsi:schemaLocation="http://romhackers.net/porno-graphic/profile profile.xsd"
    xmlns:profile="http://romhackers.net/porno-graphic/profile"
    xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance"
>
	<layouts>
		<layout name="Funworld Char">
			<plane multiplier="1">
				<offset fracnum="0" fracden="2"/>
				<offset fracnum="0" fracden="2" bits="4"/>
				<offset fracnum="1" fracden="2"/>
				<offset fracnum="1" fracden="2" bits="4"/>
      </plane>
      <x multiplier="1">
        <offset bits="3" />
        <offset bits="2" />
        <offset bits="1" />
        <offset bits="0" />
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
      <stride>64</stride>
    </layout>
  </layouts>
	<regions>
		<region name="jollycrd, jolyc3x3, jolycmzs, jolyc980, + others." length="10000">
			<file name="ch2">
				<load offset="00000" size="08000" />
			</file>
			<file name="ch1">
				<load offset="08000" size="08000" />
			</file>
		</region>
		<region name="jollycrda" length="10000">
			<file name="tab3">
				<load offset="00000" size="08000" />
			</file>
			<file name="tab2">
				<load offset="08000" size="08000" />
			</file>
		</region>
		<region name="jolycdev, jolyccra" length="10000">
			<file name="jollyb">
				<load offset="00000" size="08000" />
			</file>
			<file name="jollya">
				<load offset="08000" size="08000" />
			</file>
		</region>
		<region name="jolycdit, jolycdcy, royalcrdd, royalcrdg, + others." length="10000">
			<file name="2">
				<load offset="00000" size="08000" />
			</file>
			<file name="1">
				<load offset="08000" size="08000" />
			</file>
		</region>
		<region name="jolycdie" length="10000">
			<file name="c">
				<load offset="00000" size="08000" />
			</file>
			<file name="b">
				<load offset="08000" size="08000" />
			</file>
		</region>
		<region name="sjcd2kx3" length="10000">
			<file name="sj2">
				<load offset="00000" size="08000" />
			</file>
			<file name="sj1">
				<load offset="08000" size="08000" />
			</file>
		</region>
		<region name="bonuscrd, bonuscrda" length="10000">
			<file name="bonuscard_2">
				<load offset="00000" size="08000" />
			</file>
			<file name="bonuscard_1">
				<load offset="08000" size="08000" />
			</file>
		</region>
		<region name="clubcard" length="10000">
			<file name="c1">
				<load offset="00000" size="08000" />
			</file>
			<file name="c2">
				<load offset="08000" size="08000" />
			</file>
		</region>
		<region name="bigdeal, bigdealb" length="10000">
			<file name="003">
				<load offset="00000" size="08000" />
			</file>
			<file name="002">
				<load offset="08000" size="08000" />
			</file>
		</region>
		<region name="cuoreuno, elephfam" length="10000">
			<file name="u21">
				<load offset="00000" size="08000" />
			</file>
			<file name="u22">
				<load offset="08000" size="08000" />
			</file>
		</region>
		<region name="cuoreunoa, elephfmb, pool10, lunapark, + others." length="10000">
			<file name="u21">
				<load offset="00000" size="08000" />
			</file>
			<file name="u20">
				<load offset="08000" size="08000" />
			</file>
		</region>
		<region name="bottle10" length="10000">
			<file name="boat_2">
				<load offset="00000" size="08000" />
			</file>
			<file name="boat_1">
				<load offset="08000" size="08000" />
			</file>
		</region>
		<region name="royalcrd, gratispk, gratispka" length="10000">
			<file name="3">
				<load offset="00000" size="08000" />
			</file>
			<file name="2">
				<load offset="08000" size="08000" />
			</file>
		</region>
		<region name="royalcrdb" length="10000">
			<file name="rc_3_p1">
				<load offset="00000" size="08000" />
			</file>
			<file name="rc_2_p1">
				<load offset="08000" size="08000" />
			</file>
		</region>
		<region name="royalcrde" length="10000">
			<file name="2a">
				<load offset="00000" size="08000" />
			</file>
			<file name="1a">
				<load offset="08000" size="08000" />
			</file>
		</region>
		<region name="royalcrdt" length="10000">
			<file name="novr3_0">
				<load offset="00000" size="08000" />
			</file>
			<file name="novr2_0">
				<load offset="08000" size="08000" />
			</file>
		</region>
		<region name="royalcrdf" length="10000">
			<file name="rc_2">
				<load offset="00000" size="08000" />
			</file>
			<file name="rc_3">
				<load offset="08000" size="08000" />
			</file>
		</region>
		<region name="royalcrdh" length="10000">
			<file name="145-2">
				<load offset="00000" size="08000" />
			</file>
			<file name="145-1">
				<load offset="08000" size="08000" />
			</file>
		</region>
		<region name="royalcrdp" length="10000">
			<file name="u11_tms27c256">
				<load offset="00000" size="08000" />
			</file>
			<file name="u4_nmc27c256">
				<load offset="08000" size="08000" />
			</file>
		</region>
		<region name="royaljp, jolyjokrm" length="10000">
			<file name="02">
				<load offset="00000" size="08000" />
			</file>
			<file name="01">
				<load offset="08000" size="08000" />
			</file>
		</region>
		<region name="lluck3x3, lluck4x1" length="10000">
			<file name="12">
				<load offset="00000" size="08000" />
			</file>
			<file name="11">
				<load offset="08000" size="08000" />
			</file>
		</region>
		<region name="magicrd2, magicrd2b" length="10000">
			<file name="mc2gr2">
				<load offset="00000" size="08000" />
			</file>
			<file name="mc2gr1">
				<load offset="08000" size="08000" />
			</file>
		</region>
		<region name="magicrd2a" length="10000">
			<file name="m2_nov">
				<load offset="00000" size="08000" />
			</file>
			<file name="m1_nov">
				<load offset="08000" size="08000" />
			</file>
		</region>
		<region name="magicrdc" length="10000">
			<file name="mc2gr2b">
				<load offset="00000" size="08000" />
			</file>
			<file name="mc2gr1b">
				<load offset="08000" size="08000" />
			</file>
		</region>
		<region name="vegasslw, vegasfst" length="10000">
			<file name="v2">
				<load offset="00000" size="08000" />
			</file>
			<file name="v1">
				<load offset="08000" size="08000" />
			</file>
		</region>
		<region name="jolyjjokr, jolyjjokra" length="10000">
			<file name="impera2">
				<load offset="00000" size="08000" />
			</file>
			<file name="impera1">
				<load offset="08000" size="08000" />
			</file>
		</region>
		<region name="jolyjjokrb1, jolyjjokrb2" length="10000">
			<file name="ic26">
				<load offset="00000" size="08000" />
			</file>
			<file name="ic25">
				<load offset="08000" size="08000" />
			</file>
		</region>
		<region name="jolyjjokrc" length="10000">
			<file name="jje">
				<load offset="00000" size="08000" />
			</file>
			<file name="jjd">
				<load offset="08000" size="08000" />
			</file>
		</region>
		<region name="multiwin" length="10000">
			<file name="multiwin2">
				<load offset="00000" size="08000" />
			</file>
			<file name="multiwin1">
				<load offset="08000" size="08000" />
			</file>
		</region>
		<region name="powercrd" length="10000">
			<file name="ic11">
				<load offset="00000" size="08000" />
			</file>
			<file name="ic10">
				<load offset="08000" size="08000" />
			</file>
		</region>
		<region name="powercrd, megacard, jokercrd" length="10000">
			<file name="ic11">
				<load offset="00000" size="08000" />
			</file>
			<file name="ic10">
				<load offset="08000" size="08000" />
			</file>
		</region>
		<region name="saloon, nevadafw" length="10000">
			<file name="3s">
				<load offset="00000" size="08000" />
			</file>
			<file name="2s">
				<load offset="08000" size="08000" />
			</file>
		</region>
		<region name="funquiza" length="10000">
			<file name="ic7">
				<load offset="00000" size="08000" />
			</file>
			<file name="ic6">
				<load offset="08000" size="08000" />
			</file>
		</region>
		<region name="novoplay" length="10000">
			<file name="np1_ch2">
				<load offset="00000" size="08000" />
			</file>
			<file name="np1_ch1">
				<load offset="08000" size="08000" />
			</file>
		</region>
		<region name="intrgmes" length="10000">
			<file name="ig2ch2">
				<load offset="00000" size="08000" />
			</file>
			<file name="ig2ch1">
				<load offset="08000" size="08000" />
			</file>
		</region>
		<region name="fw_a7_11" length="10000">
			<file name="e-3">
				<load offset="00000" size="08000" />
			</file>
			<file name="e-2">
				<load offset="08000" size="08000" />
			</file>
		</region>
		<region name="fw_a0_1" length="10000">
			<file name="10">
				<load offset="00000" size="08000" />
			</file>
			<file name="9">
				<load offset="08000" size="08000" />
			</file>
		</region>
		<region name="fw_a0_1" length="10000">
			<file name="200_zg_2">
				<load offset="00000" size="08000" />
			</file>
			<file name="200_zg_1">
				<load offset="08000" size="08000" />
			</file>
		</region>
		<region name="nkoulit" length="10000">
			<file name="27c256-2">
				<load offset="00000" size="08000" />
			</file>
			<file name="27c256-1">
				<load offset="08000" size="08000" />
			</file>
		</region>
		<region name="reflexcrd" length="10000">
			<file name="27c256-2">
				<load offset="00000" size="08000" />
			</file>
			<file name="27c256-3">
				<load offset="08000" size="08000" />
			</file>
		</region>
	</regions>
</profile:profile>
