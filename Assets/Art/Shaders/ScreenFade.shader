Shader "MikeDPad/Solid Color" {
	Properties
	{
		_Color ("Color", Color) = (1,0,0,1)
	}

	SubShader
	{
		Tags
		{
			"Queue" = "Overlay"
		}

		Lighting Off
		ZWrite Off
		Blend SrcAlpha OneMinusSrcAlpha

		Pass
		{
			CGPROGRAM

			#pragma vertex vert
			#pragma fragment frag

			float4 vert(float4 v : POSITION) : SV_POSITION
			{
				return UnityObjectToClipPos(v);
			}

			uniform fixed4 _Color;

			fixed4 frag() : COLOR
			{
				return fixed4(_Color);
			}

			ENDCG
		}
	}
}
