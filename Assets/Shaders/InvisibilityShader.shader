// Made with Amplify Shader Editor
// Available at the Unity Asset Store - http://u3d.as/y3X 
Shader "InvisibilityShader"
{
	Properties
	{
		_Blending("Blending", Range( 0 , 1)) = 0
		_DistortionMap("DistortionMap", 2D) = "bump" {}
		_DistortionScale("DistortionScale", Range( 0 , 1)) = 0
		_RippleScale("RippleScale", Range( 0 , 20)) = 0
		_RippleSpeed("RippleSpeed", Range( 0 , 1)) = 0
		[HideInInspector] __dirty( "", Int ) = 1
	}

	SubShader
	{
		Tags{ "RenderType" = "Opaque"  "Queue" = "Transparent+0" "IsEmissive" = "true"  }
		Cull Back
		GrabPass{ }
		CGPROGRAM
		#include "UnityShaderVariables.cginc"
		#pragma target 3.0
		#pragma surface surf Standard keepalpha addshadow fullforwardshadows 
		struct Input
		{
			float4 screenPos;
		};

		uniform sampler2D _GrabTexture;
		uniform sampler2D _DistortionMap;
		uniform float _RippleScale;
		uniform float _RippleSpeed;
		uniform float _DistortionScale;
		uniform float _Blending;

		void surf( Input i , inout SurfaceOutputStandard o )
		{
			o.Albedo = float3(0,0,0);
			float4 ase_screenPos = float4( i.screenPos.xyz , i.screenPos.w + 0.00000000001 );
			float4 ase_screenPos7 = ase_screenPos;
			#if UNITY_UV_STARTS_AT_TOP
			float scale7 = -1.0;
			#else
			float scale7 = 1.0;
			#endif
			float halfPosW7 = ase_screenPos7.w * 0.5;
			ase_screenPos7.y = ( ase_screenPos7.y - halfPosW7 ) * _ProjectionParams.x* scale7 + halfPosW7;
			ase_screenPos7.xyzw /= ase_screenPos7.w;
			float4 screenColor2 = tex2Dproj( _GrabTexture, UNITY_PROJ_COORD( ( float4( ( UnpackNormal( tex2D( _DistortionMap, ( _RippleScale * (( ( _Time.y * _RippleSpeed ) + ase_screenPos7 )).xy ) ) ) * _DistortionScale ) , 0.0 ) + ase_screenPos7 ) ) );
			float4 temp_cast_1 = (1.0).xxxx;
			float4 lerpResult3 = lerp( screenColor2 , temp_cast_1 , _Blending);
			o.Emission = lerpResult3.rgb;
			o.Metallic = lerpResult3.r;
			o.Smoothness = lerpResult3.r;
			o.Alpha = 1;
		}

		ENDCG
	}
	Fallback "Diffuse"
	CustomEditor "ASEMaterialInspector"
}
/*ASEBEGIN
Version=14001
191;167;1552;784;299.8147;76.7919;1;True;True
Node;AmplifyShaderEditor.RangedFloatNode;17;-1338.626,722.2186;Float;False;Property;_RippleSpeed;RippleSpeed;4;0;0;0;1;0;1;FLOAT;0
Node;AmplifyShaderEditor.TimeNode;11;-1322.498,109.8916;Float;False;0;5;FLOAT4;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;16;-1082.889,157.267;Float;False;2;2;0;FLOAT;0.0;False;1;FLOAT;0.0;False;1;FLOAT;0
Node;AmplifyShaderEditor.GrabScreenPosition;7;-1178.857,418.5521;Float;False;0;0;5;FLOAT4;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SimpleAddOpNode;15;-920.3885,205.367;Float;False;2;2;0;FLOAT;0,0,0,0;False;1;FLOAT4;0;False;1;FLOAT4;0
Node;AmplifyShaderEditor.SwizzleNode;12;-789.0879,244.3676;Float;False;FLOAT2;0;1;2;3;1;0;FLOAT4;0,0,0,0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.RangedFloatNode;14;-919.0884,-29.93296;Float;False;Property;_RippleScale;RippleScale;3;0;0;0;20;0;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;13;-668.1888,111.767;Float;False;2;2;0;FLOAT;0.0;False;1;FLOAT2;0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.SamplerNode;6;-494.8568,5.352225;Float;True;Property;_DistortionMap;DistortionMap;1;0;Assets/3rd Parties/AmplifyShaderEditor/Examples/Assets/Textures/Misc/SmallWaves.png;True;0;True;bump;Auto;True;Object;-1;Auto;Texture2D;6;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0.0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1.0;False;5;FLOAT3;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.RangedFloatNode;10;-482.4963,222.3913;Float;False;Property;_DistortionScale;DistortionScale;2;0;0;0;1;0;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;9;-125.0829,122.2028;Float;False;2;2;0;FLOAT3;0,0,0;False;1;FLOAT;0,0,0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.SimpleAddOpNode;8;56.21707,306.8029;Float;False;2;2;0;FLOAT3;0,0,0,0;False;1;FLOAT4;0,0,0;False;1;FLOAT4;0
Node;AmplifyShaderEditor.RangedFloatNode;4;227,455;Float;False;Constant;_White;White;0;0;1;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.ScreenColorNode;2;235,276;Float;False;Global;_GrabScreen0;Grab Screen 0;0;0;Object;-1;False;1;0;FLOAT4;0,0,0,0;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.RangedFloatNode;5;222.0436,626.8521;Float;False;Property;_Blending;Blending;0;0;0;0;1;0;1;FLOAT;0
Node;AmplifyShaderEditor.Vector3Node;1;336,90;Float;False;Constant;_Vector0;Vector 0;0;0;0,0,0;0;4;FLOAT3;0;FLOAT;1;FLOAT;2;FLOAT;3
Node;AmplifyShaderEditor.LerpOp;3;450,281;Float;False;3;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;2;FLOAT;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.StandardSurfaceOutputNode;0;655,95;Float;False;True;2;Float;ASEMaterialInspector;0;0;Standard;InvisibilityShader;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;Back;0;0;False;0;0;Translucent;0.5;True;True;0;False;Opaque;Transparent;All;True;True;True;True;True;True;True;True;True;True;True;True;True;True;True;True;True;False;0;255;255;0;0;0;0;0;0;0;0;False;2;15;10;25;False;0.5;True;0;Zero;Zero;0;Zero;Zero;OFF;OFF;0;False;0;0,0,0,0;VertexOffset;True;False;Cylindrical;False;Relative;0;;-1;-1;-1;-1;0;0;0;False;0;16;0;FLOAT3;0,0,0;False;1;FLOAT3;0,0,0;False;2;FLOAT3;0,0,0;False;3;FLOAT;0.0;False;4;FLOAT;0.0;False;5;FLOAT;0.0;False;6;FLOAT3;0,0,0;False;7;FLOAT3;0,0,0;False;8;FLOAT;0.0;False;9;FLOAT;0.0;False;10;FLOAT;0.0;False;13;FLOAT3;0,0,0;False;11;FLOAT3;0,0,0;False;12;FLOAT3;0,0,0;False;14;FLOAT4;0,0,0,0;False;15;FLOAT3;0,0,0;False;0
WireConnection;16;0;11;2
WireConnection;16;1;17;0
WireConnection;15;0;16;0
WireConnection;15;1;7;0
WireConnection;12;0;15;0
WireConnection;13;0;14;0
WireConnection;13;1;12;0
WireConnection;6;1;13;0
WireConnection;9;0;6;0
WireConnection;9;1;10;0
WireConnection;8;0;9;0
WireConnection;8;1;7;0
WireConnection;2;0;8;0
WireConnection;3;0;2;0
WireConnection;3;1;4;0
WireConnection;3;2;5;0
WireConnection;0;0;1;0
WireConnection;0;2;3;0
WireConnection;0;3;3;0
WireConnection;0;4;3;0
ASEEND*/
//CHKSM=E7D27047ED3D7666468DE37FBFB1EE94C0A0D10D