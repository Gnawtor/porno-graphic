<?xml version="1.0" encoding="utf-8"?>
<profile:profile name="Ninja Gaiden"
    xsi:schemaLocation="http://romhackers.net/porno-graphic/profile profile.xsd"
    xmlns:profile="http://romhackers.net/porno-graphic/profile"
    xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance"
>
  <layouts>
    <layout name="8×8 txtiles and sprites">
      <plane multiplier="1">
        <offset bits="0"/>
        <offset bits="1"/>
        <offset bits="2"/>
        <offset bits="3"/>
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
      </x>
      <y multiplier="32">
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
    <layout name="16×16 bgtiles and fgtiles">
      <plane multiplier="1">
        <offset bits="0"/>
        <offset bits="1"/>
        <offset bits="2"/>
        <offset bits="3"/>
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
        <offset bits="64" />
        <offset bits="65" />
        <offset bits="66" />
        <offset bits="67" />
        <offset bits="68" />
        <offset bits="69" />
        <offset bits="70" />
        <offset bits="71" />
      </x>
      <y multiplier="32">
        <offset bits="0" />
        <offset bits="1" />
        <offset bits="2" />
        <offset bits="3" />
        <offset bits="4" />
        <offset bits="5" />
        <offset bits="6" />
        <offset bits="7" />
        <offset bits="16" />
        <offset bits="17" />
        <offset bits="18" />
        <offset bits="19" />
        <offset bits="20" />
        <offset bits="21" />
        <offset bits="22" />
        <offset bits="23" />
      </y>
      <stride>1024</stride>
    </layout>
  </layouts>
  <regions>
    <region name="Ninja Gaiden txtiles" length="10000">
      <file name="gaiden_5">
        <load offset="000000" size="10000" />
      </file>
    </region>
    <region name="Ninja Gaiden bgtiles" length="80000">
      <file name="14">
        <load offset="00000" size="20000" />
      </file>
      <file name="15">
        <load offset="20000" size="20000" />
      </file>
      <file name="16">
        <load offset="40000" size="20000" />
      </file>
      <file name="17">
        <load offset="60000" size="20000" />
      </file>
    </region>
    <region name="Ninja Gaiden fgtiles" length="80000">
      <file name="18">
        <load offset="00000" size="20000" />
      </file>
      <file name="19">
        <load offset="20000" size="20000" />
      </file>
      <file name="20">
        <load offset="40000" size="20000" />
      </file>
      <file name="21">
        <load offset="60000" size="20000" />
      </file>
    </region>
    <region name="Ninja Gaiden sprites" length="100000">
      <file name="6" lanes="16/byte">
        <load offset="00000" size="20000" />
      </file>
      <file name="7" lanes="16/byte">
        <load offset="00001" size="20000" />
      </file>
      <file name="8" lanes="16/byte">
        <load offset="40000" size="20000" />
      </file>
      <file name="9" lanes="16/byte">
        <load offset="40001" size="20000" />
      </file>
      <file name="10" lanes="16/byte">
        <load offset="80000" size="20000" />
      </file>
      <file name="11" lanes="16/byte">
        <load offset="80001" size="20000" />
      </file>
      <file name="12" lanes="16/byte">
        <load offset="C0000" size="20000" />
      </file>
      <file name="13" lanes="16/byte">
        <load offset="C0001" size="20000" />
      </file>
    </region>
  </regions>

</profile:profile>


