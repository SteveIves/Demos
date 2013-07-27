<CODEGEN_FILENAME><StructureName>.Styles.xaml</CODEGEN_FILENAME>
<PROVIDE_FILE>Default.Styles.xaml</PROVIDE_FILE>
<ResourceDictionary xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
                    xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
                    xmlns:sys="clr-namespace:System;assembly=mscorlib">

    <!--
        This file was generated by a tool. If you make changes to this file
        then those changes may be lost if the file is re-generated.
        else
    -->

    <ResourceDictionary.MergedDictionaries>
        <ResourceDictionary Source="Default.Styles.xaml"/>
    </ResourceDictionary.MergedDictionaries>
    <FIELD_LOOP>

    <!-- Original repository template is <FIELD_NAME>, <FIELD_SPEC> -->

    <Style x:Key="<FieldSqlName>_Prompt" BasedOn="{StaticResource {x:Type Label}}" TargetType="{x:Type Label}" >
        <Setter Property="Content" Value="<FIELD_PROMPT>"/>
    </Style>

    <IF TEXTBOX>
    <IF ALPHA>
    <Style x:Key="<FieldSqlName>_Style" BasedOn="{StaticResource {x:Type TextBox}}" TargetType="{x:Type TextBox}" >
        <Setter Property="MaxLength" Value="<FIELD_INPUT_LENGTH>"/>
        <Setter Property="Width" Value="<FIELD_PIXEL_WIDTH>"/>
        <IF UPPERCASE>
        <Setter Property="CharacterCasing" Value="Upper"/>
        </IF>
        <IF READONLY>
        <Setter Property="IsReadOnly" Value="True"/>
        </IF>
        <IF DISABLED>
        <Setter Property="IsEnabled" Value="False"/>
        </IF>
    </Style>
    </IF>
    <IF DECIMAL>
    <Style x:Key="<FieldSqlName>_Style" BasedOn="{StaticResource {x:Type TextBox}}" TargetType="{x:Type TextBox}" >
        <Setter Property="MaxLength" Value="<FIELD_INPUT_LENGTH>"/>
        <Setter Property="Width" Value="<FIELD_PIXEL_WIDTH>"/>
        <IF READONLY>
        <Setter Property="IsReadOnly" Value="True"/>
        </IF>
        <IF DISABLED>
        <Setter Property="IsEnabled" Value="False"/>
        </IF>
    </Style>
    </IF>
    <IF DATE>
    <Style x:Key="<FieldSqlName>_Style" BasedOn="{StaticResource {x:Type TextBox}}" TargetType="{x:Type TextBox}" >
        <Setter Property="MaxLength" Value="<FIELD_INPUT_LENGTH>"/>
        <Setter Property="Width" Value="<FIELD_PIXEL_WIDTH>"/>
        <IF READONLY>
        <Setter Property="IsReadOnly" Value="True"/>
        </IF>
        <IF DISABLED>
        <Setter Property="IsEnabled" Value="False"/>
        </IF>
    </Style>
    </IF>
    <IF TIME>
    <Style x:Key="<FieldSqlName>_Style" BasedOn="{StaticResource {x:Type TextBox}}" TargetType="{x:Type TextBox}" >
        <Setter Property="MaxLength" Value="<FIELD_INPUT_LENGTH>"/>
        <Setter Property="Width" Value="<FIELD_PIXEL_WIDTH>"/>
        <IF READONLY>
        <Setter Property="IsReadOnly" Value="True"/>
        </IF>
        <IF DISABLED>
        <Setter Property="IsEnabled" Value="False"/>
        </IF>
    </Style>
    </IF>
    <IF INTEGER>
    <Style x:Key="<FieldSqlName>_Style" BasedOn="{StaticResource {x:Type TextBox}}" TargetType="{x:Type TextBox}" >
        <Setter Property="MaxLength" Value="<FIELD_INPUT_LENGTH>"/>
        <Setter Property="Width" Value="<FIELD_PIXEL_WIDTH>"/>
        <IF READONLY>
        <Setter Property="IsReadOnly" Value="True"/>
        </IF>
        <IF DISABLED>
        <Setter Property="IsEnabled" Value="False"/>
        </IF>
    </Style>
    </IF>
    </IF>
    <IF CHECKBOX>
    <!--Need to add support for checkbox fields for field <FieldSqlName>-->
    </IF>
    <IF COMBOBOX>
    <!--Need to add support for combobox fields for field <FieldSqlName>-->
    </IF>
    <IF RADIOBUTTONS>
    <!--Need to add support for radio button fields for field <FieldSqlName>-->
    </IF>

    <sys:String x:Key="<FieldSqlName>_Regex"><FIELD_REGEX></sys:String>
    </FIELD_LOOP>

</ResourceDictionary>